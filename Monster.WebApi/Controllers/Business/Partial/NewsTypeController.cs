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

namespace Monster.Business.Controllers
{
    public partial class NewsTypeController
    {
        [HttpGet, Route("getTree")]
        public IActionResult GetNewsTypes()
        {
            return Json(Service.GetByTree());
        }
    }
}
