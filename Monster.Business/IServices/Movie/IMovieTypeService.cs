/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using Monster.Core.BaseProvider;
using Monster.Core.Utilities;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainDto;
using Monster.Entity.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monster.Business.IServices
{
    public partial interface IMovieTypeService : IService<MovieType>
    {
        Task<IList<MovieWebsiteTypeRelation>> GetTypesRelationAsync(SysMovieWebsite website);
        WebResponseContent MovieWebsiteTypePost(MovieWebsiteType type);
    }
}
