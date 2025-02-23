using Application.ContentCategories;
using Application.Core;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContentCategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PagingParams param)
        {
            var result = await Mediator.Send(new List.Query { Params = param });
            return HandlePagedResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, ContentCategory contentCat)
        {
            contentCat.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ContentCategory = contentCat }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContentCategory contentCat)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ContentCategory = contentCat }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(result);
        }
    }
}