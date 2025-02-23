using Application.Contacts;
using Application.Core;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ContactController : BaseApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PagingParams param)
        {
            var result = await Mediator.Send(new List.Query { Params = param });
            return HandlePagedResult(result);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Contact = contact }));
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}