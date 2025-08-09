using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using BooklyBookStoreApp.Persistence.Context;


namespace BooklyBookStoreApp.Persistence.Repositorires;

public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}
