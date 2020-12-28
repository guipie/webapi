/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 */
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;

namespace Monster.Business.IServices
{
    public partial interface INewsService : IService<News>
    {
        /// <summary>
        /// 网站首页推荐列表
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        object GetRecommendList(PageDataOptions options);

        /// <summary>
        /// 手机首页列表
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        object GetList(PageDataOptions options);
        News GetHandleOne(int key);
    }
}
