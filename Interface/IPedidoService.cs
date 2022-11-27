using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IPedidoService
    {
        Task DeleteAsync(int id);
        Task<List<Pedido>> GetAllAsync();
        Task<List<Pedido>> GetByFilterAsync(Expression<Func<Pedido, bool>> filter);
        Task<Pedido> SaveAsync(Pedido entity);
    }
}