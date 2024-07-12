using e_potreba.Application.Repositories;
using e_potreba.Domain.Entity;
using e_potreba.Infrastructure.DatabaseContext;

namespace e_potreba.Infrastructure.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(MsSqlDatabaseContext context) : base(context)
    {
        
    }
}
