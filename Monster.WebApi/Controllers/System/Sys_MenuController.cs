using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Monster.Core.Controllers.Basic;
using Monster.Core.Enums;
using Monster.Core.Filters;
using Monster.Entity.DomainModels;
using Monster.System.IServices;

namespace Monster.System.Controllers
{
    [Route("api/menu")]
    [ApiController, JWTAuthorize()]
    public partial class Sys_MenuController : ApiBaseController<ISys_MenuService>
    {
        private ISys_MenuService _service { get; set; }
        public Sys_MenuController(ISys_MenuService service) :
            base("System", "System", "Sys_Menu", service)
        {
            _service = service;
        } 
    }
}
