/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("WebsiteHomeConfig",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Monster.Business.Controllers
{
    [Route("AppApi/WebsiteHomeConfig"), AllowAnonymous]
    public partial class WebsiteHomeConfigController
    {
        [HttpPost,Route("GetBannerInfo")]
        public IActionResult GetBannerInfo([FromBody]PageDataOptions options)
        {
            return Json(Service.GetPageData(options).rows.Select(m => new { m.Title, m.BannerImg, m.MappingType, m.MappingId }));
        }
    }
}
