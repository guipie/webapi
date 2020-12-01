using Monster.Core.Crawling.MovieCrawling;
using Monster.Core.Enums;
using Monster.Core.Extensions;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Monster.Core.Utilities.Crawler
{
    public class Zy209Crawler : IMovieCrawlerFactory
    {
        /// <summary>
        /// 实例化配正则
        /// </summary>
        public Zy209Crawler()
        {
            Website = SysMovieWebsite.ZY209;
            MovieTypeRegex = new Regex(@".html"">(.{2,10})</a><a|onMouseOut=""mclosetime\(\)"">(.{2,5})</a>");
            PageCountRegex = new Regex(@"当前:1/(\d{1,7})页");
            PageUrl = "http://www.209zy.net/?m=vod-index-pg-{0}.html";
            PageMovieRegex = new Regex(@"<span class=""xing_vb4""><a href=""(\/\?m=.{10,30}\.html)"" target=""_blank"">.+>(\d{4}-\d{2}-\d{2})</span></li>");
        }
    }
}
