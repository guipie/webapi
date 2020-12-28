/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("NewsTag",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Monster.Core.Enums;
using Monster.Core.Filters;

namespace Monster.Business.Controllers
{
    public partial class NewsTagController
    {
        [HttpGet, Route("getByKey")]
        [ApiActionPermission("news_tag", "1", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetTreeItem(string value)
        {
            return Json(await Service.TagsByKey(value));
        }
    }
}
