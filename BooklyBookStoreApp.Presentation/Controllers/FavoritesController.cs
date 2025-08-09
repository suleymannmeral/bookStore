using BooklyBookStoreApp.Application.DTOs.CategoryDtos;
using BooklyBookStoreApp.Application.DTOs.Favorites;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Presentation.Controllers
{
    public sealed class FavoritesController : BaseApiController
    {
        public FavoritesController(IServiceManager manager) : base(manager)
        {
        }
        [HttpPost]
        public async Task<IActionResult> CreateFavorite([FromBody] CreateFavoriteDto request)
        {
            var result = await _manager.FavoriteService.CreateFavoriteAsync(request);
            return Ok( new
            {
                success = true,
                message = "Favorites has been added successfully",

                data = result
            });
        }

        [HttpGet]
        public async Task<IActionResult>GetAllFavoritesByUserIdWithBookDetails(string userid)
        {
            var result =await _manager.FavoriteService.GetAllFavoritesByUserIdWithBookDetailsAsync(userid);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFavorite([FromRoute(Name = "id")] int id)
        {
            await _manager.FavoriteService.DeleteFavoriteAsync(id, false);
            return Ok("Favorite has been deleted succesfully");
        }

    }
}
