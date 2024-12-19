using Application.Contents;
using Application.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContentController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PagingParams param)
        {
            var result = await Mediator.Send(new List.Query { Params = param });
            return HandlePagedResult(result);
        }
        [AllowAnonymous]
        [HttpGet("ClientList")]
        public async Task<IActionResult> ClientList([FromQuery] PagingParams param)
        {
            var result = await Mediator.Send(new ClientList.Query { Params = param });
            return HandlePagedResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ContentDto contentDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ContentDto = contentDto }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromForm] ContentDto contentDto)
        {
            contentDto.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ContentDto = contentDto }));
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(result);
        }
        [HttpPut("toggleIsActive/{id}")]
        public async Task<IActionResult> ToggleIsActive(Guid id)
        {
            return HandleResult(await Mediator.Send(new ToggleIsActive.Command { Id = id }));
        }

    }
}