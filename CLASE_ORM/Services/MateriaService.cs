using CLASE_ORM.Context;
using CLASE_ORM.Entities;
using CLASE_ORM.Entities.DTO.Materia;
using CLASE_ORM.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CLASE_ORM.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly AppDbContext _context;

        public MateriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MateriaDto>> GetAllAsync()
        {
            return await _context.Materias
                .Select(m => new MateriaDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre
                })
                .ToListAsync();
        }

        public async Task<Materia?> GetByIdAsync(int id)
        {
            return await _context.Materias
                .Include(m => m.Alumnos)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Materia> CreateAsync(CrearMateriaDto dto)
        {
            var materia = new Materia
            {
                Nombre = dto.Nombre
            };

            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();

            return materia;
        }

        public async Task<bool> UpdateAsync(int id, Materia materia)
        {
            var existing = await _context.Materias.FindAsync(id);
            if (existing == null) return false;

            existing.Nombre = materia.Nombre;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null) return false;

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
