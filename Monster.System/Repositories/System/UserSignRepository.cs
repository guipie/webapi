/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹UserSignRepository编写代码
 */
using Monster.System.IRepositories;
using Monster.Core.BaseProvider;
using Monster.Core.EFDbContext;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.System.Repositories
{
    public partial class UserSignRepository : RepositoryBase<UserSign> , IUserSignRepository
    {
    public UserSignRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IUserSignRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IUserSignRepository>(); } }
    }
}
