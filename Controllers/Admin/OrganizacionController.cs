using AutoMapper;
using iText.StyledXmlParser.Jsoup.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using seguridad.api.Helpers;
using seguridad.api.Models.Domain;
using seguridad.api.Models.Dto.Organizacion;
using seguridad.api.Repositories.Implementation;
using seguridad.api.Repositories.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace seguridad.api.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class OrganizacionController : ControllerBase
    {
        private readonly IGenericRepository<Organizacion> _repo;
        private readonly IMapper _mapper;

        public OrganizacionController(
            IMapper mapper,
            IGenericRepository<Organizacion> repo
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
            var dto = _mapper.Map<IEnumerable<GetOrganizacionDto>>(data);
            return Ok(dto);
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _repo.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            var dto = _mapper.Map<GetOrganizacionDto>(model);
            return Ok(dto);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] UpdateOrganizacionDto dto)
        {
            var model = await _repo.GetByIdAsync(id);

            if (model == null)
                return NotFound("Organización no encontrada.");

            _mapper.Map(dto, model);

            model.UsuarioModificacion = Guid.Parse(User.GetId());
            model.FechaModificacion = DateTime.UtcNow;

            await _repo.SaveChangesAsync();

            return NoContent();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateOrganizacionDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<Organizacion>(dto);

            entity.Id = Guid.NewGuid();
            entity.UsuarioCreacion = Guid.Parse(User.GetId());
            entity.FechaCreacion = DateTime.UtcNow;
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
            model.UsuarioModificacion = Guid.Parse(User.GetId());
            model.FechaModificacion = DateTime.UtcNow;

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
            model.UsuarioModificacion = Guid.Parse(User.GetId());
            model.FechaModificacion = DateTime.UtcNow;

            await _repo.SaveChangesAsync();

            return NoContent();
        }
    }
}
