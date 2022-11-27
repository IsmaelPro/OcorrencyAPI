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
    public class PedidoService : BaseService<Pedido>, IPedidoService
    {
        private readonly DatabaseContext _context;

        public PedidoService(DatabaseContext context) : base(context)
        {
            _context = context;


        }


        private async Task<Pedido> PostAsync(Pedido entity)
        {


            await _context.Set<Pedido>().AddAsync(entity);
            await ContextSaveAsync();
            return entity;
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


    }
}
