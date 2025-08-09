using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Application.DTOs.BasketDtos
{
    public record BasketDto
    {
        public List<BasketItemDto> Items { get; set; } = default!;
        public decimal TotalPrice { get; set; }
    }


}
