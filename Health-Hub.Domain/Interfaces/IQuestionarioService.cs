using Health_Hub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MH.Application.Interfaces
{
    public interface IQuestionarioService
    {
        Task AddSurveyAsync(Questionario s);
        Task<Questionario> GetByIdAsync(Guid id);
        Task<(IEnumerable<Questionario> items, int total)> GetSurveysPaged(Guid usuarioId, int page, int pageSize);
        Task<Relatorio> GenerateAndSaveReportAsync(Guid usuarioId, DateTime comeco, DateTime fim);
    }
}
