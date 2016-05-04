using J_LearingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_LearningSystem.Data
{
    public interface IRepository<T> where T : class, IBaseEntity {
        void Add(T entity);
        void Remove(T entity);
        T GetById(string id);
        IQueryable<T> GetAll();
        void Save();
    }

    public class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity {
        protected SystemContext _db;

        public BaseRepository(SystemContext db)
        {
            _db = db;
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public T GetById(string id)
        {
            return _db.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsQueryable();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
