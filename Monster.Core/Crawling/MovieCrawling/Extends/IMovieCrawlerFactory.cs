using Monster.Core.DBManager;
using Monster.Core.Enums;
using Monster.Core.Extensions;
using Monster.Core.Services;
using Monster.Core.Utilities;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Monster.Core.Crawling.MovieCrawling
{
    public abstract class IMovieCrawlerFactory : IMovieCrawler
    {
        protected SysMovieWebsite Website;
        protected Regex MovieTypeRegex;
        protected Regex PageCountRegex;
        protected string PageUrl;
        protected Regex PageMovieRegex;


        public static string CrawlingType = "all";
        public static ConcurrentQueue<MovieCrawlingEntity> movieCrawlingEntities = new ConcurrentQueue<MovieCrawlingEntity>();
        public static List<MoviePageCrawlingEntity> moviePageCrawlingEntities = new List<MoviePageCrawlingEntity>();

        private string Domain => Website.GetRemarkExtends();
        public static int taskStatus = -1;  //1，页采集完成//2,所有影视采集完成//3,所有影视同步数据
        private async Task StartCrawlingPage()
        {
            taskStatus = 0;
            var newestObtainTime = DBServerProvider.SqlDapper.QueryFirst<MovieEntity>("SELECT * FROM  movie where WebsiteId=@WebsiteId ORDER BY ObtainTime DESC LIMIT 1;", new { WebsiteId = (int)Website })?.ObtainTime;
            while (true)
            {
                try
                {
                    var entity = moviePageCrawlingEntities.Where(m => !m.IsSuccess).FirstOrDefault();
                    if (entity == null) { taskStatus = 1; return; }
                    var pages = await GetMovieUrlsByPage(entity.CurrentPage);
                    DBServerProvider.SqlDapper.Update(new MovieWebsite() { Id = (int)Website, LastObtainTime = DateTime.Now }, m => new { m.Id, m.LastObtainTime });
                    entity.MovieUrls = pages.Select(m => m.Item1).ToList();
                    entity.IsSuccess = entity.MovieUrls.Count > 0;
                    if (entity.IsSuccess)
                        foreach (var url in entity.MovieUrls)
                            movieCrawlingEntities.Enqueue(new MovieCrawlingEntity((int)Website, url, CurrentStatus.Crawling));

                    if (CrawlingType == "new")
                        if (pages.Max(m => m.Item2) < newestObtainTime)
                        { taskStatus = 1; return; }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Logger.Error(LoggerType.Crawling, $"影视页采集出错:{ex.Message}");
                }

            }
        }
        private async Task StartCrawlingMovie()
        {
            while (true)
            {
                try
                {
                    if (moviePageCrawlingEntities.Count == 0) return;
                    foreach (var entity in movieCrawlingEntities.Where(m => m.Status == CurrentStatus.Crawling))
                    {
                        if (taskStatus == 1 && entity == null) { taskStatus = 2; return; }
                        if (entity != null && entity.SourceUrl.IsNotNullOrEmpty())
                            (await GetMovieDetail(entity.SourceUrl)).MapValueToEntity(entity);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(LoggerType.Crawling, $"影视采集出错:{ex.Message}");
                }

            }
        }
        /// <summary>
        /// 同步数据
        /// </summary>
        private void StartSynchrodata()
        {

            string querySql = "SELECT * from movie_play;";
            var playTypes = DBServerProvider.SqlDapper.QueryList<MoviePlay>(querySql, null).Select(m => m.Name).ToArray(); //播放类别 mp4/33uu/33uuck等
            string movieTypesSql = "SELECT * from movie_website_type;";
            var movieTypes = DBServerProvider.SqlDapper.QueryList<MovieWebsiteType>(movieTypesSql, null).ToList();         //本站影视类别和资源站对应(剧情片/动作片等)
            while (true)
            {
                try
                {
                    foreach (var crawlingMovie in movieCrawlingEntities.Where(m => m.Status == CurrentStatus.Crawlinged))
                    {
                        if (crawlingMovie == null) { if (taskStatus == 2) { taskStatus = 3; return; } else continue; }
                        string queryMovieSql = "SELECT * from movie WHERE Name=@Name and WebsiteId=@WebsiteId;";
                        var movieEntity = DBServerProvider.SqlDapper.QueryFirst<MovieEntity>(queryMovieSql, new { crawlingMovie.Name, crawlingMovie.WebsiteId });
                        if (movieEntity?.SourceUrl == crawlingMovie.PlayUrls) crawlingMovie.Status = CurrentStatus.CrawlingToDb;
                        else
                        {
                            var currentMovieType = movieTypes.FirstOrDefault(m => m.Name == crawlingMovie.TypeName);
                            if (currentMovieType == null || currentMovieType.Id == 0) { Logger.Info(LoggerType.Crawling, $"影视类别[${crawlingMovie.TypeName}]未与本站绑定"); }
                            else
                                crawlingMovie.TypeId = currentMovieType.TypeId;
                            if (movieEntity?.Id > 0)
                            {
                                movieEntity.ImgUrl = crawlingMovie.ImgUrl;
                                movieEntity.NewestSet = crawlingMovie.NewestSet;
                                movieEntity.ObtainTime = crawlingMovie.ObtainTime;
                                movieEntity.ModifyDate = DateTime.Now;
                                movieEntity.PlayUrls = crawlingMovie.PlayUrls;
                                movieEntity.PlayTypes = crawlingMovie.PlayTypes;
                                if (DBServerProvider.SqlDapper.Update(movieEntity, m => new
                                {
                                    m.Id,
                                    m.ImgUrl,
                                    m.NewestSet,
                                    m.ObtainTime,
                                    m.ModifyDate,
                                    m.PlayUrls,
                                    m.PlayTypes,
                                    m.TypeName,
                                    m.TypeId
                                }) > 0)
                                    crawlingMovie.Status = CurrentStatus.CrawlingToDb;
                            }
                            else
                            {
                                var insertTypes = crawlingMovie.PlaySource.Except(playTypes).ToArray();
                                if (insertTypes.Length > 0)
                                {
                                    DBServerProvider.SqlDapper.AddRange(insertTypes.Select(m => new MoviePlay() { Name = m, CreateDate = DateTime.Now }).ToList());
                                    playTypes = DBServerProvider.SqlDapper.QueryList<MoviePlay>(querySql, null).Select(m => m.Name).ToArray();
                                }
                                movieEntity = crawlingMovie.MapToObject<MovieCrawlingEntity, MovieEntity>(null);
                                movieEntity.ModifyDate = movieEntity.CreateDate = DateTime.Now;
                                if (DBServerProvider.SqlDapper.Add(movieEntity) > 0)
                                    crawlingMovie.Status = CurrentStatus.CrawlingToDb;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(LoggerType.Crawling, $"影视同步数据库出错:{ex.Message}");
                }

            }

        }
        public async Task<List<string>> GetMovieTypes()
        {
            List<string> types = new List<string>();
            var movieCrawler = new CrawlerService();
            movieCrawler.OnStart += (s, e) =>
            {
                Console.WriteLine($"开始抓取总页数");
            };
            movieCrawler.OnError += (s, e) =>
            {
                Console.WriteLine($"总页数抓取出错了,地址【{ e.Uri}】", e.Exception);
                Thread.Sleep(1000 * 5);//暂停一下..
            };
            movieCrawler.OnCompleted += (s, e) =>
            {
                var matchs = MovieTypeRegex.Matches(e.PageSource);
                for (int i = 0; i < matchs.Count; i++)
                {
                    if (matchs[i].Groups.Count == 2 && !matchs[i].Groups[1].Value.IsNullOrEmpty())
                        types.Add(matchs[i].Groups[1].Value);
                    else if (matchs[i].Groups.Count == 3 && !matchs[i].Groups[1].Value.IsNullOrEmpty())
                        types.Add(matchs[i].Groups[1].Value);
                    else if (matchs[i].Groups.Count == 3 && !matchs[i].Groups[2].Value.IsNullOrEmpty())
                        types.Add(matchs[i].Groups[2].Value);
                }
            };
            if (Website == SysMovieWebsite.ZYkuyun)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                await movieCrawler.Start(new Uri(Domain), Encoding.GetEncoding("GB2312"));
            }
            else
                await movieCrawler.Start(new Uri(Domain));
            return types;
        }

        public virtual async Task<int> GetPageCount()
        {
            int pageCount = 0;
            var movieCrawler = new CrawlerService();
            movieCrawler.OnStart += (s, e) =>
            {
                Console.WriteLine($"开始抓取总页数");
            };
            movieCrawler.OnError += (s, e) =>
            {
                Console.WriteLine($"总页数抓取出错了,地址【{ e.Uri}】", e.Exception);
                Thread.Sleep(1000 * 5);//暂停一下..
            };
            movieCrawler.OnCompleted += (s, e) =>
            {
                var match = PageCountRegex.Match(e.PageSource);
                pageCount = match.Groups[1].Value.ToInt();
            };
            if (Website == SysMovieWebsite.ZYkuyun)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                await movieCrawler.Start(new Uri(Domain + "list/?0.html"), Encoding.GetEncoding("GB2312"));
            }
            else
                await movieCrawler.Start(new Uri(Domain));
            return pageCount;
        }
        public void Crawling(int pageCount)
        {
            for (int i = 0; i < pageCount; i++)
                moviePageCrawlingEntities.Add(new MoviePageCrawlingEntity(CrawlingType, i + 1));
            Task.Factory.StartNew(async () => await StartCrawlingPage());
            Task.Factory.StartNew(async () => await StartCrawlingMovie());
            Task.Factory.StartNew(() => StartSynchrodata());
        }
        public virtual async Task<List<(string, DateTime?)>> GetMovieUrlsByPage(int currentPage)
        {
            string url = string.Format(PageUrl, currentPage);
            var pageResult = new List<(string, DateTime?)>();
            var movieCrawler = new CrawlerService();
            movieCrawler.OnStart += (s, e) =>
            {
                Console.WriteLine($"开始抓取第{currentPage}页");
            };
            movieCrawler.OnError += (s, e) =>
            {
                Console.WriteLine($"第{currentPage}页,抓取出错了,地址【{ e.Uri}】", e.Exception);
                Thread.Sleep(1000 * 5);//暂停一下..
            };
            movieCrawler.OnCompleted += (s, e) =>
            {
                pageResult = PageMovieRegex.Matches(e.PageSource).Select(m => (Domain + m.Groups[1].Value, m.Groups[2]?.Value?.ToDateTime())).ToList();
                if (pageResult.Count == 0)
                {
                    Console.WriteLine($"第{currentPage}页未抓取到数据,地址【{ e.Uri}】");
                    Thread.Sleep(1000 * 5);//暂停一下..
                }

            };
            if (Website == SysMovieWebsite.ZYkuyun)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                await movieCrawler.Start(new Uri(url), Encoding.GetEncoding("GB2312"));
            }
            else
                await movieCrawler.Start(new Uri(url));
            return pageResult;
        }

        public virtual async Task<MovieCrawlingEntity> GetMovieDetail(string url)
        {
            MovieCrawlingEntity movieEntity = new MovieCrawlingEntity();
            var movieCrawler = new CrawlerService();
            movieCrawler.OnStart += (s, e) =>
            {
                movieEntity.SourceUrl = url;
                Console.WriteLine($"开始抓取【{ e.Uri}】");
            };
            movieCrawler.OnError += (s, e) =>
            {
                Console.WriteLine($"地址【{ e.Uri}】抓取出错了", e.Exception);
                movieEntity.Status = CurrentStatus.Crawling;
                movieEntity.CrawlingMessage = $"地址【{ e.Uri}】抓取出错了";
                Thread.Sleep(1000 * 5);//暂停一下..
            };
            movieCrawler.OnCompleted += (s, e) =>
            {
                movieEntity = new MovieCrawlingEntity()
                {
                    WebsiteId = (int)Website,
                    SourceUrl = url,
                    PlaySource = new Regex(@"<!--播放来源开始>(.+)<播放来源结束-->").Match(e.PageSource).Groups[1].Value.Split("$$$", StringSplitOptions.RemoveEmptyEntries),
                    Name = new Regex(@"<h2><!--片名开始-->(.+)<!--片名结束--></h2>").Match(e.PageSource).Groups[1].Value,
                    NewestSet = new Regex(@"<!--备注开始-->(.+)<!--备注结束-->").Match(e.PageSource).Groups[1].Value,
                    ImgUrl = new Regex(@"<img class=""lazy"" src=""(.+?)""").Match(e.PageSource).Groups[1].Value,
                    TypeName = new Regex(@"<!--类型开始-->(.+)<!--类型结束-->").Match(e.PageSource).Groups[1].Value,
                    PlayTypes = new Regex(@"<!--播放类型开始>(.*)<播放类型结束-->").Match(e.PageSource).Groups[1].Value,
                    PlayUrls = new Regex(@"<!--播放地址开始>(.*)<播放地址结束-->").Match(e.PageSource).Groups[1].Value,
                    AnotherName = new Regex(@"<!--别名开始-->(.*)<!--别名结束-->").Match(e.PageSource).Groups[1].Value,
                    Director = new Regex(@"<!--导演开始-->(.*)<!--导演结束-->").Match(e.PageSource).Groups[1].Value,
                    Actor = new Regex(@"<!--主演开始-->(.*)<!--主演结束-->").Match(e.PageSource).Groups[1].Value,
                    Region = new Regex(@"<!--地区开始-->(.*)<!--地区结束-->").Match(e.PageSource).Groups[1].Value,
                    Language = new Regex(@"<!--语言开始-->(.*)<!--语言开始-->").Match(e.PageSource).Groups[1].Value,
                    ReleaseDate = new Regex(@"<!--上映开始-->(.*)<!--上映开始-->").Match(e.PageSource).Groups[1].Value.ToDateTime(),
                    ObtainTime = new Regex(@"<li>更新：<span>(.*)</span></li> ").Match(e.PageSource).Groups[1].Value.ToDateTime(),
                    Content = new Regex(@"<!--介绍开始-->(.*)<!--介绍结束-->").Match(e.PageSource).Groups[1].Value
                };
                if (movieEntity.Name.IsNullOrEmpty())
                {
                    Console.WriteLine($"地址【{ e.Uri}】未抓取到数据.");
                    movieEntity.Status = CurrentStatus.Crawling;
                    movieEntity.CrawlingMessage = $"{e.Uri.AbsoluteUri}未抓取到影视数据";
                    Thread.Sleep(1000 * 5);//暂停一下..
                }
                else if (movieEntity.PlayUrls.IsNullOrEmpty())
                {
                    movieEntity.Status = CurrentStatus.Crawling;
                    movieEntity.CrawlingMessage = $"{e.Uri.AbsoluteUri}没有播放地址";
                }
                else
                {
                    movieEntity.AnotherName = movieEntity.AnotherName.Length > 200 ? movieEntity.AnotherName.Substring(0, 200) : movieEntity.AnotherName;
                    movieEntity.Status = CurrentStatus.Crawlinged;
                    movieEntity.CrawlingMessage = $"{movieEntity.Name}采集成功.";
                }

            };
            await movieCrawler.Start(new Uri(url));
            return movieEntity;
        }


    }
}
