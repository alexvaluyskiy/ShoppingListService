using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListService.WebApi.Core.Requests
{
    public class GetItemsDto : BaseRequestDto
    {
        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }
    }
}
