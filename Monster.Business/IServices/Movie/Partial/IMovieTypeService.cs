/*
*所有关于MovieType类的业务代码接口应在此处编写
*/
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Monster.Entity.DomainDto;
using System.Collections.Generic;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using System.Collections;

namespace Monster.Business.IServices
{
    public partial interface IMovieTypeService
    { 
        IList GetTypes(PageDataOptions options);
    }
}
