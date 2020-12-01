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
    [AllowAnonymous]
    public partial class NewsController
    {
        [HttpPost, Route("Index")]
        public IActionResult RecommendList([FromBody] PageDataOptions options)
        {
            return Json(NewsService.Instance.GetRecommendList(options));
        }
        [HttpGet, HttpPost, Route("{Id}")]
        public IActionResult NewsOne(int Id)
        {
            var model = NewsService.Instance.GetOne(Id);
            return Json(new { model.Title, model.Content, model.VideoUrl, model.Summary });
        }
    }
}
