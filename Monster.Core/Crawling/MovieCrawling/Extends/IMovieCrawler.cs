using Monster.Core.Crawling.MovieCrawling;
using Monster.Entity.DomainModels;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Monster.Core.Utilities.HttpCrawler.MovieCrawer
{
    public interface IMovieCrawler
    {
        Task<List<string>> GetMovieTypes();
        Task<int> GetPageCount();
        void Crawling(int pageCount);
        Task<List<(string, DateTime?)>> GetMovieUrlsByPage(int currentPage);
        Task<MovieCrawlingEntity> GetMovieDetail(string url);

    }
}
