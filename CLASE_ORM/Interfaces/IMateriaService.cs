using CLASE_ORM.Entities;
using CLASE_ORM.Entities.DTO.Materia;

namespace CLASE_ORM.Interfaces
{
    public interface IMateriaService
    {
        Task<List<MateriaDto>> GetAllAsync();
        Task<Materia?> GetByIdAsync(int id);
        Task<Materia> CreateAsync(CrearMateriaDto dto);
        Task<bool> UpdateAsync(int id, Materia materia);
        Task<bool> DeleteAsync(int id);
    }
}
