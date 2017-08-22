using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListService.WebApi.Core.Requests
{
    public sealed class UpdateQuantityDto : BaseRequestDto
    {
        public int Quantity { get; set; }
    }
}
