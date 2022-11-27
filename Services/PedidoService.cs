using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public class PedidoService : IPedidoService
    {
        private readonly DatabaseContext _context;

        public PedidoService(DatabaseContext context)
        {
            _context = context;


        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Pedido>().FindAsync(id);

            _context.Entry(entity).State = EntityState.Deleted;
            await ContextSaveAsync();
        }

        private async Task<Pedido> PostAsync(Pedido entity)
        {


            await _context.Set<Pedido>().AddAsync(entity);
            await ContextSaveAsync();
            return entity;
        }

        private async Task ContextSaveAsync()
        {

            await _context.SaveChangesAsync();

        }
        private async Task<Pedido> PutAsync(Pedido entity)
        {
            var dBentity = await _context.Set<Pedido>().FindAsync(entity.IdPedido);
            if (dBentity == null)
            {
                return null;
            }

            _context.Entry(entity).State = EntityState.Detached;
            _context.Entry(dBentity).State = EntityState.Detached;
            _context.Entry(entity).State = EntityState.Modified;
            await ContextSaveAsync();
            return entity;
        }

        public async Task<Pedido> SaveAsync(Pedido entity)
        {
            if (entity.IdPedido == 0)
                entity = await PostAsync(entity);
            else
                entity = await PutAsync(entity);

            return entity;
        }


        public async Task<List<Pedido>> GetAllAsync()
        {


            var query = _context.Set<Pedido>().AsQueryable();

            var result = await query.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Pedido> SearchAsync(params object[] key)
        {
            var result = await _context.Set<Pedido>().FindAsync(key);


            if (result != null)
                _context.Entry(result).State = EntityState.Detached;

            return result;
        }

        public async Task<List<Pedido>> GetByFilterAsync(Expression<Func<Pedido, bool>> filter)
        {

            IQueryable<Pedido> query = _context.Set<Pedido>()
                    .Where(filter)
                    .AsQueryable();


            if (query.Any())
                return query.AsNoTracking().ToList();
            else
            {
                return Enumerable.Empty<Pedido>().ToList();
            }
        }
    }
}
