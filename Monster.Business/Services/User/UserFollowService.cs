/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_user_followService与ISys_user_followService中编写
 */
using Monster.Business.IRepositories;
using Monster.Business.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.Business.Services
{
    public partial class UserFollowService : ServiceBase<Sys_user_follow, IUserFollowRepository>, IUserFollowService, IDependency
    {
        public UserFollowService(IUserFollowRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IUserFollowService Instance
        {
           get { return AutofacContainerModule.GetService<IUserFollowService>(); }
        }
    }
}
