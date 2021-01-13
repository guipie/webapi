/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹NewsPraiseController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.Business.IServices;
namespace Monster.Business.Controllers
{
    [Route("api/NewsPraise")]
    [PermissionTable(Name = "NewsPraise")]
    public partial class NewsPraiseController : ApiBaseController<INewsPraiseService>
    {
        public NewsPraiseController(INewsPraiseService service)
        : base(service)
        {
        }
    }
}

