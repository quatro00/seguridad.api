using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using seguridad.api.Helpers;
using seguridad.api.Models.Domain;
using seguridad.api.Models.Dto.Organizacion;
using seguridad.api.Models.Dto.Sistema;
using seguridad.api.Repositories.Interface;

namespace seguridad.api.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly IGenericRepository<Sistema> _repo;
        private readonly IMapper _mapper;

        public SistemaController(
            IMapper mapper,
            IGenericRepository<Sistema> repo
            )
        {
            _repo = repo;
            _mapper = mapper;
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repo.ListAsync();
            var dto = _mapper.Map<IEnumerable<GetSistemaDto>>(data);
            return Ok(dto);
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _repo.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            var dto = _mapper.Map<GetSistemaDto>(model);
            return Ok(dto);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] UpdateSistemaDto dto)
        {
            var model = await _repo.GetByIdAsync(id);

            if (model == null)
                return NotFound("Sistema no encontrado.");

            _mapper.Map(dto, model);

            await _repo.SaveChangesAsync();

            return NoContent();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateSistemaDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Sistema>(dto);

            entity.Id = Guid.NewGuid();
            entity.Activo = true;

            await _repo.AddAsync(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, null);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}/desactivar")]
        public async Task<IActionResult> Desactivar(Guid id)
        {
            var model = await _repo.GetByIdAsync(id);

            if (model == null)
                return NotFound("Dato no encontrado.");

            model.Activo = false;

            await _repo.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}/activar")]
        public async Task<IActionResult> Activar(Guid id)
        {
            var model = await _repo.GetByIdAsync(id);

            if (model == null)
                return NotFound("Dato no encontrado.");

            model.Activo = true;

            await _repo.SaveChangesAsync();

            return NoContent();
        }
    }
}
