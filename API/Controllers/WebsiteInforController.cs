using Application.Core;
using Application.WebsiteInfors;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class WebsiteInforController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PagingParams param)
        {
            var result = await Mediator.Send(new List.Query { Params = param });
            return HandlePagedResult(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, WebsiteInfor webInfo)
        {
            webInfo.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { WebsiteInfor = webInfo }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(result);

        }
    }
}