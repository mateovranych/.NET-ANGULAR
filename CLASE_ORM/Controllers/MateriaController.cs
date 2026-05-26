using CLASE_ORM.Entities;
using CLASE_ORM.Entities.DTO.Materia;
using CLASE_ORM.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CLASE_ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _service;

        public MateriaController(IMateriaService service)
        {

            _service = service;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var materias = await _service.GetAllAsync();
            return Ok(materias);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var materia = await _service.GetByIdAsync(id);
            if (materia == null) return NotFound();
            return Ok(materia);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearMateriaDto dto)
        {

            var created = await _service.CreateAsync(dto);
            return Ok(created);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Materia materia)
        {

            var updated = await _service.UpdateAsync(id, materia);
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
