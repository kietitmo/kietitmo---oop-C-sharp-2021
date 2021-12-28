using System;
using System.Collections.Generic;

namespace ReportApp.DAL.Interfaces
{
    public interface IRepositoryGeneric<T> where T : class 
    {
        public T GetById(Guid id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(Guid id);
        public List<T> GetAll();
        public void Save();
    }
}
