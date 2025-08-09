

namespace BooklyBookStoreApp.Application.DTOs.OrderDtos
{
    public class CreatedOrderDto
    {
        public CreatedOrderDto(int ıd, decimal totalPrice, DateTime orderDate, List<OrderBookDto> books)
        {
            Id = ıd;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Books = books;
        }

        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderBookDto> Books { get; set; }


    }



}
