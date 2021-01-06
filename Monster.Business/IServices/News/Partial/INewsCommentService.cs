/*
*所有关于NewsComment类的业务代码接口应在此处编写
*/
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Monster.Business.IServices
{
    public partial interface INewsCommentService
    {
        int UpdatePraise(int Id);
    }
}
