/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹NewsController编写
 */
using Microsoft.AspNetCore.Mvc;
using Monster.Core.Controllers.Basic;
using Monster.Entity.AttributeManager;
using Monster.Business.IServices;
using Monster.Core.Filters;
using System.Threading.Tasks;
using System.Linq;
using Monster.Business.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Monster.Business.Controllers
{
    [Route("api/News")]
    [PermissionTable(Name = "News")]
    public partial class NewsController : ApiBaseController<INewsService>
    {
        public NewsController(INewsService service)
        : base(service)
        {
        }

        [HttpPost, Route("Video/Upload")]
        [ApiActionPermission(Core.Enums.ActionPermissionOptions.Upload)]
        public async Task<IActionResult> VideoUpload()
        {
            return await base.Upload(Request.Form.Files.ToList());
        }
        [HttpGet, HttpPost, Route("admin/{Id}")]
        public IActionResult AdminNewsOne(int Id)
        {
            //设置序列化时key为默认
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver(),
                Formatting = Formatting.Indented
            };
            var model = NewsService.Instance.GetHandleOne(Id);
            return Json(model, settings);
        }
    }
}

