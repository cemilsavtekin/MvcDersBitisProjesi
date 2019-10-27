using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(DBEntities dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }


        public void Delete(int id)
        {
            var deleted = this.GetEntityByID(id);
            Delete(deleted);
        }

        public void Delete(T Entity)
        {
            var DelEntity = _dbContext.Entry(Entity);

            if (DelEntity.State != EntityState.Deleted) DelEntity.State = EntityState.Deleted;

            dbSet.Attach(Entity);
            dbSet.Remove(Entity);
        }

        public T GetEntity(Expression<Func<T, bool>> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }

        public T GetEntityByID(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? dbSet.AsEnumerable() : dbSet.Where(filter).AsEnumerable();
        }

        public void Insert(T Entity)
        {
            dbSet.Add(Entity);
        }
        
        public void Update(T Entity)
        {
            var updatedEntity = _dbContext.Entry(Entity);

            dbSet.Attach(Entity);
            updatedEntity.State = EntityState.Modified;
        }
    }
}
