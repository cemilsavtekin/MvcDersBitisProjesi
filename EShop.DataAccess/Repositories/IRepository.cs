using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataAccess.Repositories
{
    public interface IRepository<T> where T:class, new()
    {
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter=null);
        T GetEntityByID(int id);
        T GetEntity(Expression<Func<T, bool>> filter);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        void Delete(int id);
    }
}
