/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("NewsPraise",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;

namespace Monster.Business.Controllers
{
    [Route("AppApi/NewsPraise")]
    public partial class NewsPraiseController
    {
    }
}
