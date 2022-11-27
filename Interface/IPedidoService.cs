using Interface;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IPedidoService : IbaseService<Pedido>
    {
        
        Task<Pedido> SaveAsync(Pedido entity);
       
    }
}