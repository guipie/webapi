using Monster.System.IRepositories;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Core.EFDbContext;
using Monster.Entity.DomainModels;

namespace Monster.System.Repositories
{
    public partial class Sys_MenuRepository
    {
        public override VOLContext DbContext => base.DbContext;
    }
}

