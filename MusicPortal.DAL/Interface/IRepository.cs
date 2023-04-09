using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetAsync(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[]? incl);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
 
        Task DeleteAsync(T item);
        
    }
}
