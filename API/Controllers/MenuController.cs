using Application.Core;
using Application.Menus;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MenuController : BaseApiController
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
        [HttpPut("toggleIsActive/{id}")]
        public async Task<IActionResult> ToggleIsActive(string id)
        {
            return HandleResult(await Mediator.Send(new ToggleIsActive.Command { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, Menu menu)
        {
            menu.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Menu = menu }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Menu = menu }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(result);
        }
    }
}