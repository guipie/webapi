using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster.Core.BaseProvider;
using Monster.Entity.DomainModels;
using Monster.Core.Extensions.AutofacManager;
namespace Monster.System.IRepositories
{
    public partial interface ISys_LogRepository : IDependency,IRepository<Sys_Log>
    {
    }
}

