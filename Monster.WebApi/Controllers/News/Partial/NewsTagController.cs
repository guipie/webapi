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
using Monster.Entity.AttributeManager;

namespace Monster.Business.Controllers
{
    [Route("AppApi/NewsTag")]
    public partial class NewsTagController
    {
        [HttpGet, Route("GetByKeyword")]
        public IActionResult GetTreeItem(string keyword)
        {
            return Json(Service.TagsByKey(keyword));
        }
        [HttpGet, Route("Hot")]
        public IActionResult GetHotTags()
        {
            return Json(Service.HotTags());
        }
    }
}
