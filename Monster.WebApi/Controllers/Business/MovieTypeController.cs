/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹MovieTypeController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.Business.IServices;
using Monster.Core.Filters;
using Monster.Entity.DomainDto;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using System.Threading.Tasks;
using System.Collections.Generic;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;

namespace Monster.Business.Controllers
{
    [Route("api/MovieType")]
    [PermissionTable(Name = "MovieType")]
    public partial class MovieTypeController : ApiBaseController<IMovieTypeService>
    {
        public MovieTypeController(IMovieTypeService service)
        : base(service)
        {
        }

        [HttpGet, Route("GetTypesRelation")]
        [ApiActionPermission]
        public async Task<IList<MovieWebsiteTypeRelation>> GetTypesRelationAsync(SysMovieWebsite movieWebsite)
        {
            return await Service.GetTypesRelationAsync(movieWebsite);
        }

        [HttpPost, Route("MovieWebsiteTypePost")]
        [ApiActionPermission]
        public WebResponseContent MovieWebsiteTypePost([FromBody] MovieWebsiteType type)
        {
            return Service.MovieWebsiteTypePost(type);
        }
    }
}

