using System.ComponentModel.DataAnnotations;

namespace BodegaEscuela.ModelsBE
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        public required String nombre {get; set;}

        public required int telefono {get; set;}

        public required String correoElectronico {get; set;}

        public required String direccion {get; set;}

        public required int IdEstado {get; set;}
        public Estado? estado {get; set;}

        public required int IdEscuela {get; set;}
        public Escuela? escuela {get; set;}
    }
}
