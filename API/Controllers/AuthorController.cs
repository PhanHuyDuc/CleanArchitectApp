using Application.Authors;
using Application.Core;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AuthorController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PagingParams param)
        {
            var result = await Mediator.Send(new List.Query { Params = param });
            return HandlePagedResult(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Author author)
        {
            author.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Author = author }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Author = author }));
        }
    }
}