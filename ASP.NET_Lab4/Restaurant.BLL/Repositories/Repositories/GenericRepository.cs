using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.DAL;

namespace Restaurant.BLL.Repositories.Repositories;

public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
{
    private readonly ApplicationContext _db;
    private readonly DbSet<TEntity> _entity;

    public GenericRepository(ApplicationContext context)
    {
        _db = context;
        _entity = context.Set<TEntity>();
    }

    public async Task<TEntity> GetById(TKey id)
    {
        return await _entity.FindAsync(id) ?? throw new ArgumentException("Incorrect ID!");
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _entity;
    }

    public async void Create(TEntity entity)
    {
        await _entity.AddAsync(entity);
    }

    public async void CreateRange(IEnumerable<TEntity> entities)
    {
        await _entity.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        _entity.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _entity.Remove(entity);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}