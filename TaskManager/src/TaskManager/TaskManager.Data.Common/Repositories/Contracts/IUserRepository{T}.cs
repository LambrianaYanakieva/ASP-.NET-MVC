using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Common.Repositories.Contracts
{
    public interface IUserRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Add(T entity);

        void HardDelete(T entity);

        void Dispose();
    }
}
