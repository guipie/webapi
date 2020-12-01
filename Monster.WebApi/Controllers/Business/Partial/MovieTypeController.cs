/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("MovieType",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Monster.Core.Filters;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainDto;
using Monster.Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Monster.Business.Services;

namespace Monster.Business.Controllers
{
    [AllowAnonymous]
    [Route("AppApi/MovieType")]
    public partial class MovieTypeController
    {

        [HttpPost, Route("Index")]
        public IActionResult Types([FromBody]PageDataOptions options)
        {
            return Json(MovieTypeService.Instance.GetTypes(options));
        }
    }
}
