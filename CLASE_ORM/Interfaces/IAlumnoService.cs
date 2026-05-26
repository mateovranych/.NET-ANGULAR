using CLASE_ORM.Entities;
using CLASE_ORM.Entities.DTO.Alumno;

namespace CLASE_ORM.Interfaces
{
    public interface IAlumnoService
    {
        Task<List<AlumnoDto>> GetAllAsync();
        Task<AlumnoDto?> GetByIdAsync(int id);
        Task<Alumno> CreateAsync(CrearAlumnoDto dto);
        Task<bool> UpdateAsync(int id, ActualizarAlumnoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
