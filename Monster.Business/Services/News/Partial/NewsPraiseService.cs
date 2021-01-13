/*
 *所有关于NewsPraise类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*NewsPraiseService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;
using System.Linq;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using Monster.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Monster.Core.ManageUser;

namespace Monster.Business.Services
{
    public partial class NewsPraiseService
    {
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            WebResponseContent responseContent = WebResponseContent.Instance;
            AddOnExecuting = (NewsPraise newsPraise, object list) =>
            {
                if (newsPraise.NewsId > 0)
                {
                    if (repository.Exists(m => m.NewsId == newsPraise.NewsId && m.CreateID == UserContext.Current.UserId))
                        return responseContent.Error("已赞过了..");
                }
                else
                    return responseContent.Error("未获取到点赞文章..");
                return responseContent.OK();
            };
            AddOnExecuted = (NewsPraise user, object list) =>
            {
                return responseContent.OK("点赞成功.");
            };
            return base.Add(saveDataModel);
        }
    }
}
