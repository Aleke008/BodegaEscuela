using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Escuela
    {
        [Key]
        public int IdEscuela { get; set; }

        public required string nombre { get; set; }

        public required int IdRol { get; set; }
        public Rol? rol { get; set; }
    }
}
