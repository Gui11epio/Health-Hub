using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;
using Health_Hub.Domain.IRepositories;
using Health_Hub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Health_Hub.Infrastructure.Repositories
{
    public class QuestionarioRepository : IQuestionarioRepository
    {

        private readonly AppDbContext _ctx;
        public QuestionarioRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Questionario s)
        {
            _ctx.Questionarios.Add(s);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Questionario s)
        {
            _ctx.Questionarios.Remove(s);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Questionario>> GetBetweenAsync(Guid usuarioId, DateTime comeco, DateTime fim)
        {
            return await _ctx.Questionarios.Where(m => m.UsuarioId == usuarioId && m.RespondidoEm >= comeco && m.RespondidoEm <= fim)
                                         .OrderBy(m => m.RespondidoEm).ToListAsync();
        }

        public async Task<Questionario> GetByIdAsync(Guid id) 
            => await _ctx.Questionarios.FindAsync(id);
        

        public async Task<(IEnumerable<Questionario> items, int total)> GetPagedAsync(Guid usuarioId, int page, int pageSize)
        {
            var q = _ctx.Questionarios.Where(m => m.UsuarioId == usuarioId).OrderByDescending(m => m.RespondidoEm);
            var total = await q.CountAsync();
            var items = await q.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }

        public async Task UpdateAsync(Questionario s)
        {
            _ctx.Questionarios.Update(s);
            await _ctx.SaveChangesAsync();
        }
    }
}
