/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("NewsType",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Monster.Core.Filters;
using Monster.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Monster.Business.Controllers
{
    [Route("AppApi/NewsType")]
    [AllowAnonymous]
    public partial class NewsTypeController
    {
        [HttpPost, Route("Index")]
        public IActionResult List([FromBody] PageDataOptions options)
        {
            var result = Service.GetPageData(options);
            return Json(new { data = result.rows.Select(m => new { m.Name, m.Id, m.Description, m.BgImg }).ToArray(), result.total });
        }

        [HttpPost,HttpGet, Route("Recommend")]
        public IActionResult RecommendList()
        {
            var result = Service.GetRecommendList();
            return Json(result);
        }
    }
}
