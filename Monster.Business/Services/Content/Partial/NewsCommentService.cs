/*
 *所有关于NewsComment类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*NewsCommentService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;
using System.Linq;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using Monster.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Monster.Business.Repositories;

namespace Monster.Business.Services
{
    public partial class NewsCommentService
    {
        public override PageGridData<NewsComment> GetPageData(PageDataOptions options)
        {
            GetPageDataOnExecuted = (PageGridData<NewsComment> data) =>
              {
                  data.rows.ForEach(item => { item.ReCount = repository.DbContext.Set<NewsComment>().Count(m => m.ParentId == item.Id); });
              };
            return base.GetPageData(options);
        }
        public int UpdatePraise(int Id)
        {
            var model = base.GetOne(Id);
            model.Praise++;
            return repository.Update(model, m => m.Praise, true);
        }
    }
}
