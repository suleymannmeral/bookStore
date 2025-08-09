﻿namespace BooklyBookStoreApp.Ui.DTOs.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureURl { get; set; }
        public string Author { get; set; }
        public string CategoryName { get; set; }
    }
}
