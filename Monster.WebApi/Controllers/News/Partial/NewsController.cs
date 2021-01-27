/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("News",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Monster.Core.Filters;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Monster.Entity.AttributeManager;
using Monster.Business.Services;

namespace Monster.Business.Controllers
{
    [Route("AppApi/News")]
    public partial class NewsController
    {
        [AllowAnonymous]
        [HttpPost, Route("Index")]
        public IActionResult RecommendList([FromBody] PageDataOptions options)
        {
            return Json(Service.GetList(options));
        }
        [AllowAnonymous]
        [HttpGet, HttpPost, Route("{Id}")]
        public IActionResult NewsOne(int Id)
        {
            return Json(Service.GetDetail(Id));
        }
         
        [HttpGet, HttpPost, Route("Like/{Id}")]
        public IActionResult LikeOne(int Id)
        {
            return Json(Service.Like(Id));
        }
        [HttpGet, HttpPost, Route("Praise/{Id}")]
        public IActionResult PraiseOne(int Id)
        {
            return Json(Service.Praise(Id));
        }
    }
}
