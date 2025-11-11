using AutoMapper;
using Health_Hub.Application.DTOs.Request;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Domain.IRepositories;
using MH.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Health_Hub.Controllers
{
    public class RelatorioController : ControllerBase
    {
        private readonly IQuestionarioService _svc;
        private readonly IRelatorioRepository _reportRepo;
        private readonly IMapper _mapper;

        public RelatorioController(IQuestionarioService svc, IRelatorioRepository reportRepo, IMapper mapper)
        {
            _svc = svc;
            _reportRepo = reportRepo;
            _mapper = mapper;
        }

        [HttpPost("generate")]
        [Authorize]
        public async Task<IActionResult> Generate([FromBody] RelatorioRequest dto)
        {
            var report = await _svc.GenerateAndSaveReportAsync(dto.UsuarioId, dto.InicioPeriodo, dto.FimPeriodo);
            var response = _mapper.Map<RelatorioResponse>(report);
            return CreatedAtAction(nameof(GetById), new { id = response.Id, version = "1.0" }, response);
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetByUser(Guid userId, int page = 1, int pageSize = 10)
        {
            var items = await _reportRepo.GetByUsuarioAsync(userId, page, pageSize);
            var total = await _reportRepo.CountByUserAsync(userId);
            var data = items.Select(r => _mapper.Map<RelatorioResponse>(r));

            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            var links = new List<object> { new { rel = "self", href = $"{baseUrl}?page={page}&pageSize={pageSize}" } };
            if (page > 1) links.Add(new { rel = "prev", href = $"{baseUrl}?page={page - 1}&pageSize={pageSize}" });
            if (page * pageSize < total) links.Add(new { rel = "next", href = $"{baseUrl}?page={page + 1}&pageSize={pageSize}" });

            return Ok(new { meta = new { total, page, pageSize }, data, links });
        }

        [HttpGet("item/{id}", Name = "GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var r = await _reportRepo.GetByIdAsync(id);
            if (r == null) return NotFound();
            return Ok(_mapper.Map<RelatorioResponse>(r));
        }
    }
}
