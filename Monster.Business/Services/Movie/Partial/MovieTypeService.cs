/*
 *所有关于MovieType类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*MovieTypeService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Microsoft.EntityFrameworkCore;
using Monster.Core.EFDbContext;
using Monster.Core.Enums;
using Monster.Core.Extensions;
using Monster.Core.Utilities;
using Monster.Core.Utilities.Crawler.MovieCrawer;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainDto;
using Monster.Entity.DomainModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Monster.Business.Services
{
    public partial class MovieTypeService
    {
        public IList GetTypes(PageDataOptions options)
        {
            var types = GetPageData(options);
            return types.rows.Where(m => m.Pid == 0).Select(m =>
            new
            {
                value = m.Id,
                label = m.Name,
                children = types.rows.Where(c => c.Pid == m.Id).Select(cc => new { value = cc.Id, label = cc.Name })
            }).ToList();
        }
    }
}
