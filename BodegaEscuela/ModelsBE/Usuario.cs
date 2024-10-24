using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        public required string nombre { get; set; }
        public required string apellido { get; set; }
        public required string correoElectronico { get; set; }

        public required string contraseña { get; set; }

        public required int IdRol {get; set;}
        public Rol? rol { get; set;}

        public required int IdEscuela { get; set; }
        public Escuela? escuela { get; set; }

        public required int IdEstado { get; set; }
        public Estado? estado { get; set; }
    }
}
