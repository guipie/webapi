/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下NewsTagService与INewsTagService中编写
 */
using Monster.Business.IRepositories;
using Monster.Business.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;
using System.Collections;
using System.Linq;

namespace Monster.Business.Services
{
    public partial class NewsTagService : ServiceBase<NewsTag, INewsTagRepository>, INewsTagService, IDependency
    {
        public NewsTagService(INewsTagRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static INewsTagService Instance
        {
           get { return AutofacContainerModule.GetService<INewsTagService>(); }
        }

        
    }
}
