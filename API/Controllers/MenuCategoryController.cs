using Application.Core;
using Application.MenuCategories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MenuCategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PagingParams param)
        {
            var result = await Mediator.Send(new List.Query { Params = param });
            return HandlePagedResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, MenuCategory menuCat)
        {
            menuCat.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { MenuCategory = menuCat }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(MenuCategory menuCat)
        {
            return HandleResult(await Mediator.Send(new Create.Command { MenuCategory = menuCat }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(result);

        }
    }
}