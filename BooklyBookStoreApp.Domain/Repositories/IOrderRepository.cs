using BooklyBookStoreApp.Domain.Entitites;


namespace BooklyBookStoreApp.Domain.Repositories;

public interface IOrderRepository : IRepositoryBase<Order>
{
    IQueryable<Order> GetAllOrdersByUserId(bool trackChanges,string userid);
    IQueryable<Order> GetOneOrderByIdAndUserId(int id, string userid, bool trackChanges);
    void CreateOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(Order order);

}
