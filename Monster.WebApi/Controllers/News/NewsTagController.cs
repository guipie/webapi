/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹NewsTagController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.Business.IServices;
using System.Threading.Tasks;
using Monster.Core.Filters;
using Monster.Core.Enums;

namespace Monster.Business.Controllers
{
    [Route("api/NewsTag")]
    [PermissionTable(Name = "NewsTag")]
    public partial class NewsTagController : ApiBaseController<INewsTagService>
    {
        public NewsTagController(INewsTagService service)
        : base(service)
        {
        }

    }
}

