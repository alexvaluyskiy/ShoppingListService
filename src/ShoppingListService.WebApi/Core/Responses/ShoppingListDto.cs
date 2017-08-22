using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListService.WebApi.Core.Responses
{
    public sealed class ShoppingListDto
    {
        public long Count { get; set; }

        public IEnumerable<ShoppingListItemDto> Items { get; set; } = new List<ShoppingListItemDto>();
    }
}
