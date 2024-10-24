using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }

        public required String estado { get; set; }
    }
}
