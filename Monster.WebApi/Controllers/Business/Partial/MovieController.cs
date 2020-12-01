/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Movie",Enums.ActionPermissionOptions.Search)]
 */

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Monster.Business.Services;

namespace Monster.Business.Controllers
{
    [Route("AppApi/Movie/")]
    [AllowAnonymous]
    public partial class MovieController
    {
        [HttpPost, Route("Index")]
        public IActionResult Types([FromBody] PageDataOptions options)
        {
            return Json(MovieService.Instance.GetMovies(options));
        }

        [HttpGet,HttpPost, Route("PlayOne/{Id}")]
        public IActionResult PlayOne(int Id)
        {
            return Json(MovieService.Instance.GetPlayOne(Id));
        }
    }
}
