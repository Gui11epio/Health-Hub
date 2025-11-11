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
    public class QuestionarioService : IQuestionarioService
    {
        private readonly IQuestionarioRepository _questionarioRepo;
        private readonly IRelatorioRepository _relatorioRepo;

        public QuestionarioService(IQuestionarioRepository questionarioRepo, IRelatorioRepository relatorioRepo)
        {
            _questionarioRepo = questionarioRepo;
            _relatorioRepo = relatorioRepo;
        }

        public async Task AddSurveyAsync(Questionario s) => await _questionarioRepo.AddAsync(s);

        public async Task<(IEnumerable<Questionario> items, int total)> GetSurveysPaged(Guid usuarioId, int page, int pageSize)
            => await _questionarioRepo.GetPagedAsync(usuarioId, page, pageSize);

        public async Task<Relatorio> GenerateAndSaveReportAsync(Guid usuarioId, DateTime comeco, DateTime fim)
        {
            var entries = (await _questionarioRepo.GetBetweenAsync(usuarioId, comeco, fim)).ToList();
            var em = entries.Any() ? entries.Average(e => e.NivelEstresse) : 0.0;
            var resumo = em >= 8 ? "Alto risco de burnout" : (em >= 5 ? "Atenção: níveis moderados" : "Dentro do esperado");

            var relatorio = new Relatorio
            {
                UsuarioId = usuarioId,
                ComecoPeriodo = comeco,
                FimPeriodo = fim,
                EstresseMedio = em,
                Resumo = resumo,
                GeradoEm = DateTime.UtcNow
            };

            await _relatorioRepo.AddAsync(relatorio);
            return relatorio;
        }

        public async Task<Questionario> GetByIdAsync(Guid id)
        {
            return await _questionarioRepo.GetByIdAsync(id);
        }
    }
}

