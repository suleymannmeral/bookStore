using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Application.DTOs.OrderDtos
{
    public record GetAllOrdersByUserIdDto(
      int Id,
      decimal TotalPrice,
      DateTime OrderDate,
      List<OrderBookDto> Books
  );

}
