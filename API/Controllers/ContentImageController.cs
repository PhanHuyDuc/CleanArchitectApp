using Application.ContentImages;
using Application.Contents;
using Microsoft.AspNetCore.Mvc;
using Delete = Application.ContentImages.Delete;

namespace API.Controllers
{
    public class ContentImageController : BaseApiController
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPost("setMain/{id}")]
        public async Task<IActionResult> SetMain(string id)
        {
            return HandleResult(await Mediator.Send(new SetMain.Command { Id = id }));
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Add(string id, [FromForm] ContentImageDto contentImageDto)
        {
            contentImageDto.ContentId = id;
            return HandleResult(await Mediator.Send(new Add.Command { ContentImageDto = contentImageDto }));
        }
        [HttpPost]
        public async Task<IActionResult> AddPhoto([FromForm] ContentImageDto contentImageDto)
        {

            return HandleResult(await Mediator.Send(new AddPhoto.Command { ContentImageDto = contentImageDto }));
        }
    }
}