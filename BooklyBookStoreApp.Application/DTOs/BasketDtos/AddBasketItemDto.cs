﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Application.DTOs.BasketDtos
{
    public class AddBasketItemDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
