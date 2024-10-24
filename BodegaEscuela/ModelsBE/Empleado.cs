using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        public required int IdTipo { get; set; }
        public TipoCedula? tipoCedula { get; set; }

        public required String cedula { get; set; }

        public required int telefono { get; set; }

        public required string direccion { get; set; }

        public required int IdUsuario { get; set; }
        public Usuario? usuario { get; set; }

        public required int IdEscuela { get; set; }
        public Escuela? escuela { get; set; } 
    }
}
