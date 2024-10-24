using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class ProductoDia
    {
        [Key]
        public int IdProductoDia { get; set; }

        public int IdProducto { get; set; }
        public Producto? producto { get; set; }

        public required DateOnly fecha { get; set; }

        public required int vendido { get; set; }
        public required double precio { get; set; }
    }
}
