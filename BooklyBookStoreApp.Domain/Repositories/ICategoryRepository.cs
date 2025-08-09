using BooklyBookStoreApp.Domain.Entitites;


namespace BooklyBookStoreApp.Domain.Repositories;

public interface ICategoryRepository:IRepositoryBase<Category>
{
    IQueryable<Category> GetAllCategories(bool trackChanges);
    IQueryable<Category> GetOneCategoryById(int id, bool trackChanges);
    void CreateCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(Category category);
}
