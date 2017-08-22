using Akka.Actor;
using Microsoft.AspNetCore.Mvc;
using ShoppingListService.WebApi.Core.Requests;
using ShoppingListService.WebApi.Core.Responses;
using System.Threading.Tasks;

namespace ShoppingListService.WebApi.Controllers
{
    [Route("api/v1/[controller]/{customerId}")]
    public class ShoppingListsController : Controller
    {
        private readonly ActorSystem system;

        public ShoppingListsController(ActorSystem system)
        {
            this.system = system;
        }

        [HttpGet("items")]
        public async Task<IActionResult> Get(string customerId, [FromQuery] GetItemsDto items)
        {
            return Ok(new ShoppingListDto());
        }

        [HttpGet("items/{name}")]
        public async Task<IActionResult> Get(string customerId, string name)
        {
            return Ok();
        }

        [HttpPost("items")]
        public async Task<IActionResult> Post(string customerId, [FromBody] AddItemDto item)
        {
            return Ok();
        }

        [HttpPut("items/{name}")]
        public async Task<IActionResult> UpdateQuantity(string customerId, string name, [FromBody] UpdateQuantityDto item)
        {
            return Ok();
        }

        [HttpDelete("items/{name}")]
        public async Task<IActionResult> Delete(string customerId, string name)
        {
            return Ok();
        }
    }
}
