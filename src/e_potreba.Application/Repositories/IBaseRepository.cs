namespace e_potreba.Application.Repositories;
public interface IBaseRepository<T>
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<List<T>> GetAll(CancellationToken cancellation);
    Task<T> GetById(Guid id, CancellationToken cancellation);
}
