using Microsoft.AspNetCore.SignalR;
using Monster.Core.Crawling.MovieCrawling;
using Monster.Core.Enums;
using Monster.Core.Extensions;
using Monster.Core.Utilities;
using Monster.Core.Utilities.Crawler.MovieCrawer;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Monster.Business.Services.Movie.Partial
{
    public class MovieWebsiteServiceHub : Hub
    {
        /// <summary>
        /// 爬取任务
        /// </summary>
        /// <param name="movieWebsite"></param>
        /// <returns></returns>
        public async Task<WebResponseContent> CrawlingMonitor(SysMovieWebsite movieWebsite, string type = "all")
        {
            if (IMovieCrawlerFactory.taskStatus != 3 && IMovieCrawlerFactory.taskStatus != -1)
                return WebResponseContent.Instance.Error("有正在进行的采集任务，请清空后再试..");
            CrawlingReset();
            IMovieCrawler factory = MovieCrawlerCore.Instance(movieWebsite);
            int pageCount = await factory.GetPageCount();
            IMovieCrawlerFactory.CrawlingType = type;

            if (pageCount > 0) { factory.Crawling(pageCount); return WebResponseContent.Instance.OK("任务初始化成功,请查看监控日志", pageCount); }
            return WebResponseContent.Instance.Error("任务初始化失败,请重试");
        }
        /// <summary>
        /// 重置清理采集任务
        /// </summary>
        public void CrawlingReset()
        {
            IMovieCrawlerFactory.taskStatus = -1;
            IMovieCrawlerFactory.movieCrawlingEntities = new System.Collections.Concurrent.ConcurrentQueue<MovieCrawlingEntity>();
            IMovieCrawlerFactory.moviePageCrawlingEntities = new List<MoviePageCrawlingEntity>();
        }
        /// <summary>
        /// 查询采集日志
        /// </summary>
        public object CrawlingLog(PageDataOptions options)
        {

            var searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
            var name = searchParametersList.FirstOrDefault(m => m.Name == "Name" && m.Value.IsNotNullOrEmpty());
            var statues = searchParametersList.FirstOrDefault(m => m.Name == "Status" && m.Value.IsNotNullOrEmpty());
            var list = IMovieCrawlerFactory.movieCrawlingEntities.Where(m => true);
            if (name != null)
                list = list.Where(m => m.Name.Contains(name.Value));
            if (statues != null)
                list = list.Where(m => statues.Value.Contains(m.Status.GetEnumValue<CurrentStatus>().ToString()));
            var result = list.Select(m => new { m.Name, m.SourceUrl, m.Status, m.CrawlingMessage }).Skip((options.Page - 1) * options.Rows).Take(options.Rows).ToList();
            string msg = "暂无采集任务";
            if (IMovieCrawlerFactory.movieCrawlingEntities.Count > 0)
                msg = $"第{(IMovieCrawlerFactory.taskStatus > 0 ? IMovieCrawlerFactory.taskStatus : 1)}步：" +
                      $"当前共采集[{IMovieCrawlerFactory.moviePageCrawlingEntities.Where(m => m.IsSuccess).Count()}]页数据," +
                      $"[{IMovieCrawlerFactory.movieCrawlingEntities.Where(m => m.Status == CurrentStatus.Crawling).Count()}]条影视待采集," +
                      $"[{IMovieCrawlerFactory.movieCrawlingEntities.Where(m => m.Status == CurrentStatus.CrawlingToDb).Count()}]条已同步数据库";
            return new { rows = result, total = list.Count(), extra = msg };
        }


    }
}
