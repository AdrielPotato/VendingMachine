using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VendingMachine.Services.Interfaces.Services
{
    public interface IServiceBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
