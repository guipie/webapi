/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下UserSignService与IUserSignService中编写
 */
using Monster.Sys.IRepositories;
using Monster.Sys.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.Sys.Services
{
    public partial class UserSignService : ServiceBase<UserSign, IUserSignRepository>, IUserSignService, IDependency
    {
        public UserSignService(IUserSignRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IUserSignService Instance
        {
           get { return AutofacContainerModule.GetService<IUserSignService>(); }
        }
    }
}
