using BooklyBookStoreApp.Application.DTOs.BookDtos;
using BooklyBookStoreApp.Application.DTOs.CategoryDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Presentation.Abstractions;
using BooklyBookStoreApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;


namespace BooklyBookStoreApp.Presentation.Controllers;

public sealed class CategoriesController : BaseApiController
{
    public CategoriesController(IServiceManager manager) : base(manager)
    {
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _manager.CategoryService.GetAllCategoriesAsync(false);
        return Ok(result);
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
    {
        var result = await _manager.CategoryService.CreateCategoryAsync(createCategoryDto);
        return CreatedAtAction(nameof(GetOneCategoryById), new
        {
            success = true,
            message = "Category has been added successfully",
            data = result
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneCategoryById(int id)
    {
        var result = await _manager.CategoryService.GetOneCategoryByIdAsync(id, false);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute(Name = "id")] int id)
    {
        await _manager.CategoryService.DeleteCategoryAsync(id, false);
        return Ok("Category has been deleted succesfully");
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory([FromRoute(Name = "id")] int id, [FromBody] UpdateCategoryDto updateCategoryDto)
    {

        await _manager.CategoryService.UpdateCategoryAsync(id, updateCategoryDto , false);
        return Ok("Category has been updated successfully");
    }
}
