using System;
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
    public class RelatorioRepository : IRelatorioRepository
    {

        private readonly AppDbContext _ctx;
        public RelatorioRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Relatorio r)
        {
            _ctx.Relatorios.Add(r);
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CountByUserAsync(Guid usuarioId)
            => await _ctx.Relatorios.CountAsync(r => r.UsuarioId == usuarioId);
        

        public async Task DeleteAsync(Relatorio r)
        {
            _ctx.Relatorios.Remove(r);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Relatorio> GetByIdAsync(Guid id)
           => await _ctx.Relatorios.FindAsync(id);
        

        public async Task<IEnumerable<Relatorio>> GetByUsuarioAsync(Guid usuarioId, int page, int pageSize)
        {
            return await _ctx.Relatorios.Where(r => r.UsuarioId == usuarioId)
                .OrderByDescending(r => r.GeradoEm)
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
