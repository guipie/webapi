using Monster.Core.Crawling.MovieCrawling;
using Monster.Core.Extensions;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using System;

namespace Monster.Core.Utilities.Crawler.MovieCrawer
{
    public class MovieCrawlerCore
    {
        public static IMovieCrawler Instance(SysMovieWebsite movieWebsite)
        {
            IMovieCrawler movieCrawler;
            if (movieWebsite == SysMovieWebsite.ZY209)
                movieCrawler = new Zy209Crawler();
            else if (movieWebsite == SysMovieWebsite.ZYkuyun)
                movieCrawler = new ZyKuYunCrawler();
            else
                throw new BusinessException("未配置此网站");
            return movieCrawler;
        }

    }
}
