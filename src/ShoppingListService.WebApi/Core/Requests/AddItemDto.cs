using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListService.WebApi.Core.Requests
{
    public sealed class AddItemDto : BaseRequestDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
