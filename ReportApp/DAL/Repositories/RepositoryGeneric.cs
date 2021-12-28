using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Context;

namespace ReportApp.DAL.Repositories
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        protected ReportContext _db { get; set; }
        protected DbSet<T> _table = null;

        public RepositoryGeneric()
        {
            _db = new ReportContext();
            _table = _db.Set<T>();
        }
        public RepositoryGeneric(ReportContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _table.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            T temp = _table.Find(id);
            _table.Remove(temp);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(Guid id)
        {
            return _table.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
