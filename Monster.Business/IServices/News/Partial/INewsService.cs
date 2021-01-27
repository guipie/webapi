/*
*所有关于News类的业务代码接口应在此处编写
*/
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;
using System.Linq.Expressions;
namespace Monster.Business.IServices
{
    public partial interface INewsService
    {
        /// <summary>
        /// 内容列表
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        object GetList(PageDataOptions options);
        object GetDetail(int key);

        WebResponseContent Like(int key);
        WebResponseContent Praise(int key);
    }
}
