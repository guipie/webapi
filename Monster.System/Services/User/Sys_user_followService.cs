/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_user_followService与ISys_user_followService中编写
 */
using Monster.System.IRepositories;
using Monster.System.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.System.Services
{
    public partial class Sys_user_followService : ServiceBase<Sys_user_follow, ISys_user_followRepository>, ISys_user_followService, IDependency
    {
        public Sys_user_followService(ISys_user_followRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_user_followService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_user_followService>(); }
        }
    }
}
