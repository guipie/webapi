using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Core.Controllers.Basic;
using Monster.Core.Enums;
using Monster.Core.Filters;
using Monster.Entity.AttributeManager;
using Monster.Entity.DomainModels;
using Monster.System.IServices;

namespace Monster.System.Controllers
{
    [Route("api/Sys_Role")]
    [PermissionTable(Name = "Sys_Role")]
    public partial class Sys_RoleController : ApiBaseController<ISys_RoleService>
    {
        public Sys_RoleController(ISys_RoleService service)
        : base("System", "System", "Sys_Role", service)
        {

        }
    }
}


