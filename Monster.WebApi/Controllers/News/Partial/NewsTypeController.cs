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
using Monster.Core.Utilities;

namespace Monster.Business.Controllers
{
    [Route("AppApi/NewsType")]
    [AllowAnonymous]
    public partial class NewsTypeController
    {
        /// <summary>
        /// 论坛列表
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpPost, Route("Index")]
        public IActionResult List([FromBody] PageDataOptions options)
        {
            var result = Service.GetPageData(options);
            return Json(new { data = result.rows.Select(m => new { m.Name, m.Id, m.Description, m.BgImg }).ToArray(), result.total });
        }
        /// <summary>
        /// 获取配置的推荐论坛
        /// </summary>
        /// <returns></returns>
        [HttpPost, HttpGet, Route("Recommend")]
        public IActionResult RecommendList()
        {
            var result = Service.GetRecommendList();
            return Json(result);
        }
        /// <summary>
        /// 根据论坛名称获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost, HttpGet, Route("{name}")]
        public WebResponseContent Detail(string name)
        {
            var result = Service.GetOneByName(name);
            if (result == null)
                return WebResponseContent.Instance.Error($"没有找到论坛${name}");
            return WebResponseContent.Instance.OK(result);
        }
        /// <summary>
        /// 关注
        /// </summary>
        /// <param name="Id">论坛名称</param>
        /// <returns></returns>
        [HttpPost, HttpGet, Route("Follow/{Id}")]
        public WebResponseContent Follow(int Id)
        {
            return Service.FollowBbs(Id);
        }
        [HttpPost, HttpGet, Route("Follow/Exist/{Id}")]
        public JsonResult FollowExist(int Id)
        {
            return Json(Service.FollowExist(Id));
        }
    }
}
