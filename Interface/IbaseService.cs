using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IbaseService<T> where T : class
    {

    Task DeleteAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
   
    Task<T> SearchAsync(params object[] key);
}
    }
