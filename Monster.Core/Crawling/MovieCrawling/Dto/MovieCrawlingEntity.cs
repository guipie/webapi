using Monster.Core.Extensions;
using Monster.Entity.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monster.Core.Crawling.MovieCrawling
{
    public class MovieCrawlingEntity : MovieEntity
    {
        public string CrawlingMessage { get; set; }
        public CurrentStatus Status { get; set; }

        /// <summary>
        /// 影视播放类型(33uuck,33uu等)
        /// </summary>
        public string[] PlaySource { get; set; }
        public MovieCrawlingEntity() { }
        public MovieCrawlingEntity(int websiteId, string url, CurrentStatus status) { SourceUrl = url; WebsiteId = websiteId; Status = status; Name = ""; }

    }

    public enum CurrentStatus
    {
        Crawling = 1,
        Crawlinged = 2,
        CrawlingToDb = 3
    }
}
