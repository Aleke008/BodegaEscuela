using BodegaEscuela.ModelsBE;
using Microsoft.EntityFrameworkCore;

namespace BodegaEscuela.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
            
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoCedula> TipoCedula { get; set; }
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoDia> ProductoDias { get; set; }
    }
}
