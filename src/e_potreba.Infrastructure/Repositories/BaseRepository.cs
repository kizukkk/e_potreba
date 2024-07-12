using e_potreba.Application.Repositories;
using e_potreba.Domain.Entity.Common;
using e_potreba.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace e_potreba.Infrastructure.Repositories;
public class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _table;

    public BaseRepository(MsSqlDatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<T>();
    }

    public async void Create(T entity) =>
        await _table.AddAsync(entity);

    public void Delete(T entity) =>
        _table.Remove(entity);

    public Task<List<T>> GetAll(CancellationToken cancellation) => 
        _table.ToListAsync(cancellation);

    public Task<T> GetById(Guid id, CancellationToken cancellation) =>
        _table.FirstOrDefaultAsync(x => x.Id == id, cancellation);

    public void Update(T entity) =>
        _table.Update(entity);
}
