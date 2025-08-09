using BooklyBookStoreApp.Application.DTOs.CategoryDtos;

namespace BooklyBookStoreApp.Application.Services;

public interface ICategoryService
{
    Task<IEnumerable<GetAllCategoriesDto>> GetAllCategoriesAsync(bool trackChanges);
    Task<GetOneCategoryByIdDto> GetOneCategoryByIdAsync(int id, bool trackChanges);
    Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task DeleteCategoryAsync(int id, bool trackChanges);
    Task UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto, bool trackChanges);



}
