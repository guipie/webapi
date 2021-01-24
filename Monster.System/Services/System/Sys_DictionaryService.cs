/*
 *Author：jxx
 *Contact：283591387@qq.com
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */
using Monster.Sys.IRepositories;
using Monster.Sys.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;

namespace Monster.Sys.Services
{
    public partial class Sys_DictionaryService : ServiceBase<Sys_Dictionary, ISys_DictionaryRepository>, ISys_DictionaryService, IDependency
    {
        public Sys_DictionaryService(ISys_DictionaryRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_DictionaryService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_DictionaryService>(); }
        }
    }
}

