using Monster.Sys.IRepositories;
using Monster.Sys.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.Sys.Services
{
    public partial class Sys_MenuService : ServiceBase<Sys_Menu, ISys_MenuRepository>, ISys_MenuService, IDependency
    {
        public Sys_MenuService(ISys_MenuRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_MenuService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_MenuService>(); }
        }
    }
}

