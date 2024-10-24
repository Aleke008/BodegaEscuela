using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        public required String nombre { get; set; }

        public required double precio { get; set; }

        public required int stock { get; set; }

        public required int IdProveedor { get; set; }
        public Proveedor? proveedor { get; set; }

        public required int IdEscuela { get; set; }
        public Escuela? escuela { get; set; }
    }
}
