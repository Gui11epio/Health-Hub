using Health_Hub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MH.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateAsync(Usuario usuario, string senha);
        Task<Usuario> GetByIdAsync(Guid id);
        Task<Usuario> GetByEmailAsync(string email);
        Task<IEnumerable<Usuario>> GetAllAsync(int page, int pageSize);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);
        Task<bool> ValidateCredentialsAsync(string email, string senha);
    }
}
