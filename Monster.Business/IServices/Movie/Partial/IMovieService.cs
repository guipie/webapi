/*
*所有关于Movie类的业务代码接口应在此处编写
*/
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using Monster.Core.Crawling.MovieCrawling;
using System.Collections;

namespace Monster.Business.IServices
{
    public partial interface IMovieService
    {
        object GetMovies(PageDataOptions options);
        object GetPlayOne(int id);
    }
}
