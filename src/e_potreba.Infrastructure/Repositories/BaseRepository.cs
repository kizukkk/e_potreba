using e_potreba.Application.Repositories;

namespace e_potreba.Infrastructure.Repositories;
public class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    public void Create(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
