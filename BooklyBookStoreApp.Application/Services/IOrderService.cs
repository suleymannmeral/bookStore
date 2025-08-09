
using BooklyBookStoreApp.Application.DTOs.CategoryDtos;
using BooklyBookStoreApp.Application.DTOs.OrderDtos;

namespace BooklyBookStoreApp.Application.Services;

public interface IOrderService
{
    Task<IEnumerable<GetAllOrdersByUserIdDto>> GetAllOrdersByUserIdAsync(bool trackChanges,string userid);
    Task<GetOneCategoryByIdDto> GetOneCategoryByIdAsync(int id, bool trackChanges);
    Task<CreatedOrderDto> CreateOrderAsync(string userid);
    Task DeleteCategoryAsync(int id, bool trackChanges);
    Task UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto, bool trackChanges);

}
