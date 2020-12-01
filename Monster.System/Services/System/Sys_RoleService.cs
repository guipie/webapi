/*
 *Author：jxx
 *Contact：283591387@qq.com
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */
using Monster.System.IRepositories;
using Monster.System.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.System.Services
{
    public partial class Sys_RoleService : ServiceBase<Sys_Role, ISys_RoleRepository>, ISys_RoleService, IDependency
    {
        public Sys_RoleService(ISys_RoleRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_RoleService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_RoleService>(); }
        }
    }
}

