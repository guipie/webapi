/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下NewsTypeService与INewsTypeService中编写
 */
using Monster.Business.IRepositories;
using Monster.Business.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.Business.Services
{
    public partial class NewsTypeService : ServiceBase<NewsType, INewsTypeRepository>, INewsTypeService, IDependency
    {
        public NewsTypeService(INewsTypeRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static INewsTypeService Instance
        {
           get { return AutofacContainerModule.GetService<INewsTypeService>(); }
        }
    }
}
