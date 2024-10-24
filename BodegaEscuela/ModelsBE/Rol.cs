using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        public required String rol { get; set; }
    }
}
