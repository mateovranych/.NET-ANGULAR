using CLASE_ORM.Context;
using CLASE_ORM.Entities;
using CLASE_ORM.Entities.DTO.Alumno;
using CLASE_ORM.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CLASE_ORM.Services
{
    public class AlumnoService : IAlumnoService
    {
        
        private readonly AppDbContext _context;

        public AlumnoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AlumnoDto>> GetAllAsync()
        {

            return await 
                _context.Alumnos
                .Include(a => a.Materia)
                .Select(a => new AlumnoDto
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Materia = a.Materia.Nombre,
                    Email = a.Email,
                })
                .ToListAsync();

        }

        public async Task<AlumnoDto?> GetByIdAsync(int id)
        {

            
            return await _context.Alumnos
                .Include(a => a.Materia)
                .Where(a => a.Id == id)
                .Select(a => new AlumnoDto
                {

                    Id = a.Id,
                    Nombre = a.Nombre,
                    Materia = a.Materia.Nombre,
                    Email = a.Email,    
                    

                })
                .FirstOrDefaultAsync();

        }
        
        public async Task<Alumno> CreateAsync(CrearAlumnoDto dto)
        {

            var alumno = new Alumno
            {
                Nombre = dto.Nombre,
                MateriaId = dto.MateriaId,
                Email = dto.Email,
            };

            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();

            return alumno;

        }

        public async Task<bool> UpdateAsync(int id, ActualizarAlumnoDto dto)
        {

            var existing = await _context.Alumnos.FindAsync(id);
            if (existing == null) return false;

            existing.Nombre = dto.Nombre;
            existing.MateriaId = dto.MateriaId;
            existing.Email = dto.Email;

            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> DeleteAsync(int id)
        {

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null) return false;

            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
