/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹NewsTypeController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.Business.IServices;
namespace Monster.Business.Controllers
{
    [Route("api/NewsType")]
    [PermissionTable(Name = "NewsType")]
    public partial class NewsTypeController : ApiBaseController<INewsTypeService>
    {
        public NewsTypeController(INewsTypeService service)
        : base(service)
        {
        }
    }
}

