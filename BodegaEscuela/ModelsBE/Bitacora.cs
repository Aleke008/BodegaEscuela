using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Bitacora
    {
        [Key]
        public int IdBitacora { get; set; }

        public required String accion { get; set; }

        public required DateTime fechaHora { get; set; }

        public required String descripcion { get; set; }

        public required int IdUsuario { get; set; }
        public Usuario? usuario { get; set; }
    }
}
