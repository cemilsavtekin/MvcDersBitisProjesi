using EShop.DataAccess.Repositories;
using EShop.DataAccess.UOW;
using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Business
{
    public class DBHelper<T> where T : class, new()
    {
        private static IUnitOfWork uow = null;
        private static IRepository<T> repo = null;

        public static void Commit()
        {
            uow.Commit();
        }

        static DBHelper()
        {
            uow= new UnitOfWork(new DBEntities());
            repo= uow.GetRepository<T>();
        }

        public static IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return repo.GetList(filter);
        }

        public static T GetEntity(Expression<Func<T, bool>> filter)
        {
            return repo.GetEntity(filter);
        }

        public static T GetEntityByID(int id)
        {
            return repo.GetEntityByID(id);
        }

        public static void Delete(int id)
        {
            repo.Delete(id);
        }

        public static void Delete(T Entity)
        {
            repo.Delete(Entity);
        }

        public static void Update(T Entity)
        {
            repo.Update(Entity);
        }

        public static void Insert(T Entity)
        {
            repo.Insert(Entity);
        }



    }
}
