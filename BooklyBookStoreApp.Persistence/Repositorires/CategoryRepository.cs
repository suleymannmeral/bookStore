using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using BooklyBookStoreApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Persistence.Repositorires
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateCategory(Category category)=>Create(category);


        public void DeleteCategory(Category category)=>Delete(category);

        public IQueryable<Category> GetAllCategories(bool trackChanges)=>
            FindAll(trackChanges);


        public IQueryable<Category> GetOneCategoryById(int id, bool trackChanges)=>
            FindByCondition(c => c.Id == id, trackChanges);

        public void UpdateCategory(Category category)=>Update(category);

    }
}
