using Monster.Core.Enums;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monster.Core.Crawling.MovieCrawling
{
    public class MoviePageCrawlingEntity
    {
        public int CurrentPage { get; set; }
        public string CrawlingType { get; set; }

        public List<string> MovieUrls { get; set; }
        public MoviePageCrawlingEntity(string crawlingType, int currentPage) { CrawlingType = crawlingType; CurrentPage = currentPage; }

        public bool IsSuccess { get; set; }
    }
}
