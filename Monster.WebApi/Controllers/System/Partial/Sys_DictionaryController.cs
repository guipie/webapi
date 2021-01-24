using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.Core.Controllers.Basic;
using Monster.Core.Extensions;
using Monster.Core.Filters;
using Monster.Sys.IServices;
using Microsoft.AspNetCore.Authorization;

namespace Monster.Sys.Controllers
{
    [AllowAnonymous]
    [Route("AppApi/Dic")]
    public partial class Sys_DictionaryController
    {
        [HttpGet, HttpPost, Route("GetDicByKey")]
        public async Task<IActionResult> GetDicByKey(string key)
        {
             
            return Content((await Service.GetVueDictionary(new string[1] { key })).Serialize());
        }
    }
}
