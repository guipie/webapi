/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("MovieWebsite",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Entity.DomainModels;
using Monster.Core.Filters;
using System.Text.RegularExpressions;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Core.Utilities.Crawler.MovieCrawer;
using Monster.Business.Services.Movie.Partial;
using Monster.Core.Extensions;

namespace Monster.Business.Controllers
{
    public partial class MovieWebsiteController
    {

    }
}
