using EShop.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataAccess.UOW
{
    public interface IUnitOfWork
    {
        Repository<T> GetRepository<T>() where T : class, new();
        int Commit();
    }
}
