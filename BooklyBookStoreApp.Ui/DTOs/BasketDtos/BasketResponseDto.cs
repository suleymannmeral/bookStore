namespace BooklyBookStoreApp.Ui.DTOs.BasketDtos
{
    public class BasketResponseDto
    {
        public List<BasketItemDto> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
