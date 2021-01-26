/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("NewsAppend",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monster.Entity.DomainModels;

namespace Monster.Business.Controllers
{
    [Route("AppApi/NewsAppend")]
    public partial class NewsAppendController
    {
        [HttpPost, Route("Index"), AllowAnonymous]
        public IActionResult NewsAppendList([FromBody] PageDataOptions options)
        {
            return Json(Service.GetPageData(options));
        }
    }
}
