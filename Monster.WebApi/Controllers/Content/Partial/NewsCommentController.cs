/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("NewsComment",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Monster.Core.Utilities;
using Monster.Core.Extensions;

namespace Monster.Business.Controllers
{
    [AllowAnonymous]
    [Route("AppApi/Comment")]
    public partial class NewsCommentController
    {
        [HttpPost, Route("Save")]
        public new async Task<ActionResult> Add([FromBody] SaveModel saveModel)
        {
            return await base.Add(saveModel);
        }
        [HttpPost, Route("Update/Praise/{Id}")]
        public WebResponseContent UpdatePraise(int Id)
        {
            return WebResponseContent.Instance.Info(Service.UpdatePraise(Id) > 0);
        }
        [HttpPost, Route("Index")]
        public async Task<ActionResult> Comments([FromBody] PageDataOptions options)
        {
            return await GetPageData(options);
        }
    }
}
