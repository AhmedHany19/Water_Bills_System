using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositiory
{
    public interface IBaseRepositiory<T> where T:class
    {
        T GetById(string code);
        Task<T> GetByIdAsync(string code);
        T Find(Expression<Func<T, bool>> predicate, string[] includes = null);
        bool Exists(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> GetAll(string[] includes = null);
        Task<IEnumerable<T>> GetAllAsync();
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        int Count();
        

    }
}
