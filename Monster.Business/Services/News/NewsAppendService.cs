/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下NewsAppendService与INewsAppendService中编写
 */
using Monster.Business.IRepositories;
using Monster.Business.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.Business.Services
{
    public partial class NewsAppendService : ServiceBase<NewsAppend, INewsAppendRepository>, INewsAppendService, IDependency
    {
        private readonly INewsRepository newsRepository;
        public NewsAppendService(INewsAppendRepository repository, INewsRepository repository1)
             : base(repository)
        {
            newsRepository = repository1;
            Init(repository);
        }
        public static INewsAppendService Instance
        {
            get { return AutofacContainerModule.GetService<INewsAppendService>(); }
        }
    }
}
