/*
 *所有关于NewsAppend类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*NewsAppendService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;
using System.Linq;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using Monster.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace Monster.Business.Services
{
    public partial class NewsAppendService
    {
        public object GetPageDataExtends(PageDataOptions options)
        {
            var data = base.GetPageData(options);
            var rows = from p in data.rows
                       join users in repository.DbContext.Set<Sys_User>()
                       on p.CreateID equals users.User_Id
                       select new
                       {
                           p.Content,
                           p.CreateDate,
                           users.HeadImageUrl,
                           users.UserTrueName
                       };
            return new { rows, data.total };
        }
        public new WebResponseContent Add(SaveModel saveModel)
        {
            base.AddOnExecuted = (NewsAppend model, object list) =>
            {
                News news = new News() { NewsId = model.NewsId }.SetModifyDefaultVal();
                newsRepository.Update(news, m => new { m.ModifyDate, m.Modifier, m.ModifyID }, true);
                return WebResponseContent.Instance.OK("成功回帖");
            };
            return base.Add(saveModel);
        }
    }
}
