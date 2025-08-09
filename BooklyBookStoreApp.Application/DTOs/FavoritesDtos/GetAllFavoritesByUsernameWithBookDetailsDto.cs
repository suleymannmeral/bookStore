using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Application.DTOs.FavoritesDtos
{
    public record GetAllFavoritesByUsernameWithBookDetailsDto
    {
        public int FavoriteId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
