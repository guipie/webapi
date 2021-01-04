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
        public object TagsByKey(string key)
        {
            return repository.FindAsIQueryable(m => key.IsNullOrEmpty() || m.Tag.Trim().Contains(key.Trim())).Take(10).Select(m => new { m.Tag, m.UseCount });
        }
        public object HotTags()
        {
            return repository.FindAsIQueryable(m => true).Take(10).OrderByDescending(m => m.UseCount).Select(m => new { m.Tag, m.UseCount });
        }
    }
}
