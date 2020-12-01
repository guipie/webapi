using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Monster.Core.Controllers.Basic;
using Monster.Core.Extensions;
using Monster.Core.Filters;
using Monster.System.IServices;

namespace Monster.System.Controllers
{
    [Route("api/Sys_Dictionary")]
    public partial class Sys_DictionaryController : ApiBaseController<ISys_DictionaryService>
    {
        public Sys_DictionaryController(ISys_DictionaryService service)
        : base("System", "System", "Sys_Dictionary", service)
        {
        }
    }
}
