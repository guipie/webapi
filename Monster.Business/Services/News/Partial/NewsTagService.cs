/*
 *所有关于NewsTag类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*NewsTagService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;
using System.Linq;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using Monster.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Monster.Business.Services
{
    public partial class NewsTagService
    {
        public async Task<IList> TagsByKey(string key)
        {
            return await repository.FindAsIQueryable(m => key.IsNullOrEmpty() ? true : m.Tag.Trim().Contains(key.Trim())).Take(20).Select(m => new { key = m.Id.ToString(), value = m.Tag }).ToListAsync();
        }

        public IQueryable<NewsTag> TagsByNewsId(int newsId)
        {
            var tagMappings = repository.DbContext.Set<NewsTagMapping>().Where(m => m.NewsId == newsId).Select(m => m.TagId).ToArray();
            return repository.FindAsIQueryable(m => tagMappings.Contains(m.Id));
        }
    }
}
