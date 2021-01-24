using Monster.Sys.IRepositories;
using Monster.Sys.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.Sys.Services
{
    public partial class Sys_LogService : ServiceBase<Sys_Log, ISys_LogRepository>, ISys_LogService, IDependency
    {
        public Sys_LogService(ISys_LogRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_LogService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_LogService>(); }
        }
    }
}

