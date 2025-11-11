using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;
using Health_Hub.Domain.IRepositories;
using MH.Application.Interfaces;

namespace Health_Hub.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioService(IUsuarioRepository repo) { _repo = repo; }

        public async Task<Usuario> CreateAsync(Usuario usuario, string senha)
        {
            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
            await _repo.AddAsync(usuario);
            return usuario;
        }

        public async Task DeleteAsync(Guid id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u != null) await _repo.DeleteAsync(u);
        }

        public async Task<Usuario> GetByEmailAsync(string email) => await _repo.GetByEmailAsync(email);
        public async Task<Usuario> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);
        public async Task<IEnumerable<Usuario>> GetAllAsync(int page, int pageSize) => await _repo.GetAllAsync(page, pageSize);
        public async Task UpdateAsync(Usuario usuario) => await _repo.UpdateAsync(usuario);

        public async Task<bool> ValidateCredentialsAsync(string email, string senha)
        {
            var u = await _repo.GetByEmailAsync(email);
            if (u == null) return false;
            return BCrypt.Net.BCrypt.Verify(senha, u.SenhaHash);
        }
    }
}

