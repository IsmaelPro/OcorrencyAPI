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
    public class OcorrenciaService
    {
        private readonly DatabaseContext _context;

        public OcorrenciaService(DatabaseContext context)
        {
            _context = context;


        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Ocorrência>().FindAsync(id);

            _context.Entry(entity).State = EntityState.Deleted;
            await ContextSaveAsync();
        }

        private async Task<Ocorrência> PostAsync(Ocorrência entity)
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
            await _context.Set<Ocorrência>().AddAsync(entity);
            await ContextSaveAsync();
            return entity;
        }

        private async Task ContextSaveAsync()
        {

            await _context.SaveChangesAsync();

        }
        private async Task<Ocorrência> PutAsync(Ocorrência entity)
        {
            var dBentity = await _context.Set<Ocorrência>().FindAsync(entity.IdOcorrência);
            if (dBentity == null)
            {
                return null;
            }

            _context.Entry(entity).State = EntityState.Detached;
            _context.Entry(entity).State = EntityState.Modified;
            await ContextSaveAsync();
            return entity;
        }

        public async Task<Ocorrência> SaveAsync(Ocorrência entity)
        {
            if (entity.IdOcorrência == 0)
                entity = await PostAsync(entity);
            else
                entity = await PutAsync(entity);

            return entity;
        }


        public async Task<List<Ocorrência>> GetAllAsync()
        {


            var query = _context.Set<Ocorrência>().AsQueryable();

            var result = await query.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<List<Ocorrência>> GetByFilterAsync(Expression<Func<Ocorrência, bool>> filter)
        {

            IQueryable<Ocorrência> query = _context.Set<Ocorrência>()
                    .Where(filter)
                    .AsQueryable();


            if (query.Any())
                return query.AsNoTracking().ToList();
            else
            {
                return Enumerable.Empty<Ocorrência>().ToList();
            }
        }
    }
}
