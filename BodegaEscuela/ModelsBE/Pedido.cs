using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        public required DateOnly fechaPedido { get; set; }
        public DateOnly fechaEntrega { get; set; }

        public required int IdEstado { get; set; }

        public Estado? estado { get; set; }
    }
}
