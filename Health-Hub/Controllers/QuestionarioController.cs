using AutoMapper;
using Health_Hub.Application.DTOs.Request;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Domain.Entities;
using MH.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Health_Hub.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/questionarios")]
    public class QuestionarioController : ControllerBase
    {
        private readonly IQuestionarioService _svc;
        private readonly IMapper _mapper;

        public QuestionarioController(IQuestionarioService svc, IMapper mapper)
        {
            _svc = svc;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionarioRequest dto)
        {
            var questionario = _mapper.Map<Questionario>(dto);
            await _svc.AddSurveyAsync(questionario);
            var response = _mapper.Map<QuestionarioResponse>(questionario);

            return CreatedAtAction(nameof(GetById), new { id = response.Id, version = "1.0" }, response);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetPaged(Guid usuarioId, int page = 1, int pageSize = 10)
        {
            var (items, total) = await _svc.GetSurveysPaged(usuarioId, page, pageSize);
            var data = items.Select(i => _mapper.Map<QuestionarioResponse>(i));

            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            var links = new List<object>
            {
                new { rel = "self", href = $"{baseUrl}?page={page}&pageSize={pageSize}" }
            };
            if (page > 1) links.Add(new { rel = "prev", href = $"{baseUrl}?page={page - 1}&pageSize={pageSize}" });
            if (page * pageSize < total) links.Add(new { rel = "next", href = $"{baseUrl}?page={page + 1}&pageSize={pageSize}" });

            return Ok(new { meta = new { total, page, pageSize }, data, links });
        }

        [HttpGet("item/{id}", Name = "GetSurveyById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var survey = await _svc.GetByIdAsync(id);
            if (survey == null) return NotFound();

            return Ok(_mapper.Map<QuestionarioResponse>(survey));
        }
    }
}
