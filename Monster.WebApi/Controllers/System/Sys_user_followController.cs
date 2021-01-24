/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Sys_user_followController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Business.IServices;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.Sys.IServices;
namespace Monster.Sys.Controllers
{
    [Route("api/Sys_user_follow")]
    [PermissionTable(Name = "Sys_user_follow")]
    public partial class Sys_user_followController : ApiBaseController<IUserFollowService>
    {
        public Sys_user_followController(IUserFollowService service)
        : base(service)
        {
        }
    }
}

