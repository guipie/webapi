/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹MoviePlayController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.Business.IServices;
namespace Monster.Business.Controllers
{
    [Route("api/MoviePlay")]
    [PermissionTable(Name = "MoviePlay")]
    public partial class MoviePlayController : ApiBaseController<IMoviePlayService>
    {
        public MoviePlayController(IMoviePlayService service)
        : base(service)
        {
        }
    }
}

