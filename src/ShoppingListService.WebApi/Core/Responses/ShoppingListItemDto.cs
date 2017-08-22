using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListService.WebApi.Core.Responses
{
    public sealed class ShoppingListItemDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
