namespace CLASE_ORM.Entities
{
    public class Materia
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        
        //AGREGAMOS LA NAVEGACIÓN INVERSA
        public List<Alumno> Alumnos { get; set; }
    }
}
