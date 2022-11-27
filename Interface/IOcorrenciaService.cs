using Interface;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IOcorrenciaService : IbaseService<Ocorrencia>
    {
        
        Task<Ocorrencia> SaveAsync(Ocorrencia entity);
       
    }
}