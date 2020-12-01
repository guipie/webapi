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
    public partial class Sys_DictionaryListService : ServiceBase<Sys_DictionaryList, ISys_DictionaryListRepository>, ISys_DictionaryListService, IDependency
    {
        public Sys_DictionaryListService(ISys_DictionaryListRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_DictionaryListService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_DictionaryListService>(); }
        }
    }
}

