using e_potreba.Application.Repositories;
using e_potreba.Domain.Entity;
using e_potreba.Infrastructure.DatabaseContext;

namespace e_potreba.Infrastructure.Repositories;
public class ToiletRepository : BaseRepository<Toilet>, IToiletRepository
{
    public ToiletRepository(MsSqlDatabaseContext context) : base(context)
    {
        
    }
}
