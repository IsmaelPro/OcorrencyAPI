using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IOcorrenciaService
    {
        Task DeleteAsync(int id);
        Task<List<Ocorrencia>> GetAllAsync();
        Task<List<Ocorrencia>> GetByFilterAsync(Expression<Func<Ocorrencia, bool>> filter);
        Task<Ocorrencia> SaveAsync(Ocorrencia entity);
        Task<Ocorrencia> SearchAsync(params object[] key);
    }
}