using DataAccess.Context;
using Microsoft.AspNetCore.Http;
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
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly DatabaseContext _context;

        public OcorrenciaService(DatabaseContext context)
        {
            _context = context;


        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Ocorrencia>().FindAsync(id);

            _context.Entry(entity).State = EntityState.Deleted;
            await ContextSaveAsync();
        }

        private async Task<Ocorrencia> PostAsync(Ocorrencia entity)
        {


            var ocorrenciaDb = GetByFilterAsync(
                x => x.TipoOcorrencia.Equals(entity.TipoOcorrencia)).Result;


            TimeSpan timeSinceCreated;
            var isValid = true;
            if (ocorrenciaDb != null)
            {

                ocorrenciaDb.ForEach(x =>
                {
                    timeSinceCreated = DateTime.Now - entity.HoraOcorrencia;
                    if (timeSinceCreated.TotalMinutes <= 10) isValid = false;
                });
                if (!isValid) return null;

            }
            await _context.Set<Ocorrencia>().AddAsync(entity);
            await ContextSaveAsync();
            return entity;
        }

        private async Task ContextSaveAsync()
        {

            await _context.SaveChangesAsync();

        }
        private async Task<Ocorrencia> PutAsync(Ocorrencia entity)
        {
            var dBentity = await _context.Set<Ocorrencia>().FindAsync(entity.IdOcorrencia);
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

        public async Task<Ocorrencia> SaveAsync(Ocorrencia entity)
        {
            if (entity.IdOcorrencia == 0)
                entity = await PostAsync(entity);
            else
                entity = await PutAsync(entity);

            return entity;
        }


        public async Task<List<Ocorrencia>> GetAllAsync()
        {


            var query = _context.Set<Ocorrencia>().AsQueryable();

            var result = await query.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Ocorrencia> SearchAsync(params object[] key)
        {
            var result = await _context.Set<Ocorrencia>().FindAsync(key);


            if (result != null)
                _context.Entry(result).State = EntityState.Detached;

            return result;
        }

        public async Task<List<Ocorrencia>> GetByFilterAsync(Expression<Func<Ocorrencia, bool>> filter)
        {

            IQueryable<Ocorrencia> query = _context.Set<Ocorrencia>()
                    .Where(filter)
                    .AsQueryable();


            if (query.Any())
                return query.AsNoTracking().ToList();
            else
            {
                return Enumerable.Empty<Ocorrencia>().ToList();
            }
        }
    }
}
