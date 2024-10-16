﻿namespace Udemy.BankApp.Data.Interfaceses
{
    public interface IRepository<T> where T:class,new()
    {
        void Create(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T GetById(object id);
        void Update(T entity);
        public IQueryable<T> GetQueryable();

    }
}
