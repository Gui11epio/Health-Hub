using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;

namespace Health_Hub.Domain.IRepositories
{
    public interface IQuestionarioRepository
    {
        Task AddAsync(Questionario s);
        Task<Questionario> GetByIdAsync(Guid id);
        Task<(IEnumerable<Questionario> items, int total)> GetPagedAsync(Guid usuarioId, int page, int pageSize);
        Task<IEnumerable<Questionario>> GetBetweenAsync(Guid usuarioId, DateTime comeco, DateTime fim);
        Task UpdateAsync(Questionario s);
        Task DeleteAsync(Questionario s);
    }
}
