/*
*所有关于NewsAppend类的业务代码接口应在此处编写
*/
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;
using System.Linq.Expressions;
namespace Monster.Business.IServices
{
    public partial interface INewsAppendService
    {
        object GetPageDataExtends(PageDataOptions options);
        new WebResponseContent Add(SaveModel saveModel);
    }
}
