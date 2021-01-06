/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹UserSignController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.System.IServices;
namespace Monster.System.Controllers
{
    [Route("api/UserSign")]
    [PermissionTable(Name = "UserSign")]
    public partial class UserSignController : ApiBaseController<IUserSignService>
    {
        public UserSignController(IUserSignService service)
        : base(service)
        {
        }
    }
}

