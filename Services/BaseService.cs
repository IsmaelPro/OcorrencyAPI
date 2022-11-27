using DataAccess.Context;
using Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
   public class BaseService <T> : IbaseService<T> where T: class
    {
        private readonly DatabaseContext _context;

        public BaseService(DatabaseContext context) 
        {
            _context = context;


        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            _context.Entry(entity).State = EntityState.Deleted;
            await ContextSaveAsync();
        }



        protected async Task ContextSaveAsync()
        {

            await _context.SaveChangesAsync();

        }
       
 


        public async Task<List<T>> GetAllAsync()
        {


            var query = _context.Set<T>().AsQueryable();

            var result = await query.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<T> SearchAsync(params object[] key)
        {
            var result = await _context.Set<T>().FindAsync(key);


            if (result != null)
                _context.Entry(result).State = EntityState.Detached;

            return result;
        }

        public async Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {

            IQueryable<T> query = _context.Set<T>()
                    .Where(filter)
                    .AsQueryable();


            if (query.Any())
                return query.AsNoTracking().ToList();
            else
            {
                return Enumerable.Empty<T>().ToList();
            }
        }
    }
}
