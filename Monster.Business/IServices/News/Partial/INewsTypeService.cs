/*
*所有关于NewsType类的业务代码接口应在此处编写
*/
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using System.Collections;
using System.Linq;

namespace Monster.Business.IServices
{
    public partial interface INewsTypeService
    {
        object GetRecommendList();
    }
}
