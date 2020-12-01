using Monster.Core.Enums;
using Monster.Core.Extensions;
using Monster.Core.Utilities;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Monster.Core.Crawling.MovieCrawling
{
    public class ZyKuYunCrawler : IMovieCrawlerFactory
    {
        /// <summary>
        /// 实例化配正则
        /// </summary>
        public ZyKuYunCrawler()
        {
            Website = SysMovieWebsite.ZYkuyun;
            MovieTypeRegex = new Regex(@".html"">(.{2,10})</a></em></li>|target=_self>(.{2,10})</a>");
            PageCountRegex = new Regex(@"页次:1/(\d{1,5})页");
            PageUrl = "http://www.kuyunzy1.com/list/?0-{0}.html";
            PageMovieRegex = new Regex(@"align=""left""><a href=""(\/detail\/\?\d{1,10}.html)"" target=""_blank"">[\s\S]+?000"">(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})</font></td>");
        }

        public override async Task<MovieCrawlingEntity> GetMovieDetail(string url)
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
            };
            movieCrawler.OnCompleted += (s, e) =>
            {
                movieEntity = new MovieCrawlingEntity()
                {
                    WebsiteId = (int)Website,
                    SourceUrl = url,
                    //PlaySource = new Regex(@"<h1>来源:(.{1,10})</h1>").Matches(e.PageSource).Select(m => m.Groups[1].Value).ToArray(),
                    //PlayUrls = new Regex(@"<!--播放地址开始>(.*)<播放地址结束-->").Match(e.PageSource).Groups[1].Value,
                    //PlayTypes = new Regex(@"<!--播放类型开始>(.*)<播放类型结束-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    Name = new Regex(@"<!--影片名称开始代码-->(.*)<!--影片名称结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    AnotherName = new Regex(@"<!--影片名称开始代码-->(.*)<!--影片名称结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    NewestSet = new Regex(@"<!--影片备注开始代码-->(.*)<!--影片备注结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    ImgUrl = new Regex(@"<!--影片图片开始代码-->(.*)<!--影片图片结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    TypeName = new Regex(@"<!--影片类型开始代码-->(.*)<!--影片类型结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    Director = new Regex(@"<!--影片导演开始代码-->(.*)<!--影片导演结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    Actor = new Regex(@"<!--影片演员开始代码-->(.*)<!--影片演员结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    Region = new Regex(@"<!--影片地区开始代码-->(.*)<!--影片地区结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    Language = new Regex(@"<!--影片语言开始代码-->(.*)<!--影片语言结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags(),
                    ReleaseDate = new Regex(@"<!--上映日期开始代码-->(.*)<!--上映日期结束代码-->").Match(e.PageSource).Groups[1].Value.ToDateTime(),
                    ObtainTime = new Regex(@"<!--影片更新时间开始代码-->(.*)<!--影片更新时间结束代码-->").Match(e.PageSource).Groups[1].Value.ToDateTime(),
                    Content = new Regex(@"<!--影片介绍开始代码-->(.*)<!--影片介绍结束代码-->").Match(e.PageSource).Groups[1].Value.RemoveHTMLTags()
                };
                var plays = new Regex(@"<h1>来源:(.{1,10})</h1>[\s\S]{1,10}<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">([\s\S]+?)</table>").Matches(e.PageSource);
                movieEntity.PlaySource = plays.Select(m => m.Groups[1].Value).ToArray();
                movieEntity.PlayTypes = string.Join("$$$", movieEntity.PlaySource);
                for (int i = 0; i < plays.Count; i++)
                    movieEntity.PlayUrls += string.Join("<br>", new Regex("<a>(.+?)</a>").Matches(plays[i].Groups[2].Value).Select(m => m.Groups[1].Value).ToArray()) + "$$$";

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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            await movieCrawler.Start(new Uri(url), Encoding.GetEncoding("GB2312"));
            return movieEntity;
        }

    }
}
