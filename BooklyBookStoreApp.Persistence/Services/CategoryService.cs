using AutoMapper;
using BooklyBookStoreApp.Application.DTOs.CategoryDtos;
using BooklyBookStoreApp.Application.Exceptions;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace BooklyBookStoreApp.Persistence.Services;

public class CategoryService(IRepositoryManager repositoryManager, IMapper mapper) : ICategoryService
{
    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var category = mapper.Map<Category>(createCategoryDto);
        repositoryManager.Category.Create(category);
        await repositoryManager.Save();
        return mapper.Map<CategoryDto>(category);

    }

    public async Task DeleteCategoryAsync(int id, bool trackChanges)
    {
         var category=await CheckCategoryExist(id, trackChanges);
        repositoryManager.Category.Delete(category);
        await repositoryManager.Save();
    }

    public async Task<IEnumerable<GetAllCategoriesDto>> GetAllCategoriesAsync(bool trackChanges)
    {
        var categories = await repositoryManager.Category.GetAllCategories(trackChanges).ToListAsync();
       return  mapper.Map<IEnumerable<GetAllCategoriesDto>>(categories);
    }

    public async Task<GetOneCategoryByIdDto> GetOneCategoryByIdAsync(int id, bool trackChanges)
    {
        var category = await CheckCategoryExist(id, trackChanges);
        return  mapper.Map<GetOneCategoryByIdDto>(category);


    }

    public async Task UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto, bool trackChanges)
    {
        var category = await CheckCategoryExist(id, trackChanges);
        mapper.Map(updateCategoryDto, category); 
        repositoryManager.Category.Update(category);
        await repositoryManager.Save();

    }

    private async Task<Category> CheckCategoryExist(int id, bool trackChanges)
    {
        var category = await repositoryManager.Category.GetOneCategoryById(id, trackChanges).FirstOrDefaultAsync();
        if (category is null)
        {
            throw new CategoryNotFoundException(id);
        }
        return category;

    }

}
