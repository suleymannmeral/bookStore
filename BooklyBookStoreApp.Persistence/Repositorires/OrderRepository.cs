using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using BooklyBookStoreApp.Persistence.Context;

namespace BooklyBookStoreApp.Persistence.Repositorires
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateOrder(Order order)=>Create(order);


        public void DeleteOrder(Order order)=>Delete(order);

        public IQueryable<Order> GetAllOrdersByUserId(bool trackChanges, string userid)=>FindAll(trackChanges)
            .Where(o => o.UserId == userid);


        public IQueryable<Order> GetOneOrderByIdAndUserId(int id, string userid, bool trackChanges)=>
            FindByCondition(o => o.Id == id && o.UserId == userid, trackChanges);

        public void UpdateOrder(Order order)=>Update(order);

    }
}
