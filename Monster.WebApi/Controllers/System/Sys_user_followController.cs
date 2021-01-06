/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Sys_user_followController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.System.IServices;
namespace Monster.System.Controllers
{
    [Route("api/Sys_user_follow")]
    [PermissionTable(Name = "Sys_user_follow")]
    public partial class Sys_user_followController : ApiBaseController<ISys_user_followService>
    {
        public Sys_user_followController(ISys_user_followService service)
        : base(service)
        {
        }
    }
}

