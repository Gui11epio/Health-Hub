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
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext _ctx;
        public UsuarioRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Usuario usuario)
        {
            _ctx.Usuarios.Add(usuario);
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CountAsync() => await _ctx.Usuarios.CountAsync();
        

        public async Task DeleteAsync(Usuario usuario)
        {
            _ctx.Usuarios.Remove(usuario);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync(int page, int pageSize)
        {
            return await _ctx.Usuarios.OrderBy(u => u.Nome)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Usuario> GetByEmailAsync(string email)
            => await _ctx.Usuarios.FirstOrDefaultAsync(u => u.EmailCorporativo == email);


        public async Task<Usuario> GetByIdAsync(Guid id)
            => await _ctx.Usuarios.FindAsync(id);
        

        public async Task UpdateAsync(Usuario usuario)
        {
            _ctx.Usuarios.Update(usuario);
            await _ctx.SaveChangesAsync();
        }
    }
}
