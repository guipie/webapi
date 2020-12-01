/*
*所有关于NewsTag类的业务代码接口应在此处编写
*/
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Monster.Business.IServices
{
    public partial interface INewsTagService
    {
        Task<IList> TagsByKey(string key);

        IQueryable<NewsTag> TagsByNewsId(int newsId);
    }
}
