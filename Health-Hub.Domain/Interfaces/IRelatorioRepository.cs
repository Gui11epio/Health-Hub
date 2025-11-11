using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;

namespace Health_Hub.Domain.IRepositories
{
    public interface IRelatorioRepository
    {
        Task AddAsync(Relatorio r);
        Task<Relatorio> GetByIdAsync(Guid id);
        Task<IEnumerable<Relatorio>> GetByUsuarioAsync(Guid usuarioId, int page, int pageSize);
        Task<int> CountByUserAsync(Guid usuarioId);
        Task DeleteAsync(Relatorio r);
    }
}
