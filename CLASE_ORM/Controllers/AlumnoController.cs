using CLASE_ORM.Entities;
using CLASE_ORM.Entities.DTO.Alumno;
using CLASE_ORM.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLASE_ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {

        private readonly IAlumnoService _service;

        public AlumnoController(IAlumnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var alumnos = await _service.GetAllAsync();
            return Ok(alumnos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var alumno = await _service.GetByIdAsync(id);
            if (alumno == null) return NotFound();

            return Ok(alumno);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearAlumnoDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarAlumnoDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

    }
}
