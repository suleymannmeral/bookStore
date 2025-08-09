using System.Linq.Expressions;

namespace BooklyBookStoreApp.Domain.Repositories;

public interface IRepositoryBase<T>
{
    // Crud İşlemleri
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression,bool trachChanges);
    void Create(T entity);  
    void Update(T entity);
    void Delete(T entity);
}
