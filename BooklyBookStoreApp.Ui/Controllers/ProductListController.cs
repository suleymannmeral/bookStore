using BooklyBookStoreApp.Ui.DTOs.BookDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BooklyBookStoreApp.Ui.Controllers
{
    public class ProductListController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7174/api/Books");

            if (!response.IsSuccessStatusCode)
            {
                
                return View(new List<BookDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<BookDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(products);
        }
    }
}
