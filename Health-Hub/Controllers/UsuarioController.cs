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
    [Route("api/v{version:apiVersion}/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _svc;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService svc, IMapper mapper)
        {
            _svc = svc;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioRequest dto)
        {
            var existing = await _svc.GetByEmailAsync(dto.EmailCorporativo);
            if (existing != null)
                return Conflict("Email já está sendo utilizado");

            var usuario = _mapper.Map<Usuario>(dto);
            var created = await _svc.CreateAsync(usuario, dto.Senha);
            var response = _mapper.Map<UsuarioResponse>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.Id, version = "1.0" }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var u = await _svc.GetByIdAsync(id);
            if (u == null) return NotFound();
            return Ok(_mapper.Map<UsuarioResponse>(u));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var usuarios = await _svc.GetAllAsync(page, pageSize);
            var result = _mapper.Map<IEnumerable<UsuarioResponse>>(usuarios);
            return Ok(new { meta = new { page, pageSize }, data = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UsuarioRequest dto)
        {
            var u = await _svc.GetByIdAsync(id);
            if (u == null) return NotFound();

            _mapper.Map(dto, u);
            await _svc.UpdateAsync(u);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _svc.DeleteAsync(id);
            return NoContent();
        }
    }
}
