﻿namespace Restaurant.BLL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void CreateRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }
}