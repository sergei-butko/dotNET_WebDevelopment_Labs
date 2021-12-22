namespace Restaurant.BLL.Repositories.Interfaces;

public interface IGenericRepository<TEntity, TKey> where TEntity : class
{
    Task<TEntity> GetById(TKey id);
    IEnumerable<TEntity> GetAll();
    void Create(TEntity entity);
    void CreateRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Save();
}