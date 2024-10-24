using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class TipoCedula
    {
        [Key]
        public int IdTipo { get; set; }

        public required string tipo { get; set; }
    }
}
