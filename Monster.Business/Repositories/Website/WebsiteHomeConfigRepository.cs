/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹WebsiteHomeConfigRepository编写代码
 */
using Monster.Business.IRepositories;
using Monster.Core.BaseProvider;
using Monster.Core.EFDbContext;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.Business.Repositories
{
    public partial class WebsiteHomeConfigRepository : RepositoryBase<WebsiteHomeConfig> , IWebsiteHomeConfigRepository
    {
    public WebsiteHomeConfigRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IWebsiteHomeConfigRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IWebsiteHomeConfigRepository>(); } }
    }
}
