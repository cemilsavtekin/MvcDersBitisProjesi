using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DataAccess.Repositories;
using EShop.Entities;
using System.Data.Entity;

namespace EShop.DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBEntities _dbContext;

        public UnitOfWork(DBEntities dbContext)
        {
            Database.SetInitializer<DBEntities>(null);

            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_dbContext);
        }
    }
}
