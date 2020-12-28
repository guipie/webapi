/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹MovieWebsiteController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.Business.IServices;
using Monster.Business.Services.Movie.Partial;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;

namespace Monster.Business.Controllers
{
    [Route("api/MovieWebsite")]
    [PermissionTable(Name = "MovieWebsite")]
    public partial class MovieWebsiteController : ApiBaseController<IMovieWebsiteService>
    {
        public MovieWebsiteController(IMovieWebsiteService service)
        : base(service)
        {
        }

        [HttpGet, Route("Crawling")]
        public async Task<WebResponseContent> MovieCrawling(SysMovieWebsite movieWebsite, string type = "all")
        {
            return await new MovieWebsiteServiceHub().CrawlingMonitor(movieWebsite, type);
        }
        [HttpPost, Route("CrawlingLog")]
        public IActionResult CrawlingLog([FromBody] PageDataOptions options)
        {
            return Json(new MovieWebsiteServiceHub().CrawlingLog(options));
        }
        [HttpGet, Route("Crawling/Reset")]
        public IActionResult MovieWebsiteReset()
        {
            new MovieWebsiteServiceHub().CrawlingReset();
            return Json("重置成功");
        }
    }
}

