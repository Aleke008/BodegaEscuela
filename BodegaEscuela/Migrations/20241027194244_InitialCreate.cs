using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodegaEscuela.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TipoCedula",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCedula", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaPedido = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaEntrega = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    estadoIdEstado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Estados_estadoIdEstado",
                        column: x => x.estadoIdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado");
                });

            migrationBuilder.CreateTable(
                name: "Escuelas",
                columns: table => new
                {
                    IdEscuela = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    rolIdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuelas", x => x.IdEscuela);
                    table.ForeignKey(
                        name: "FK_Escuelas_Roles_rolIdRol",
                        column: x => x.rolIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    estadoIdEstado = table.Column<int>(type: "int", nullable: true),
                    IdEscuela = table.Column<int>(type: "int", nullable: false),
                    escuelaIdEscuela = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_Proveedores_Escuelas_escuelaIdEscuela",
                        column: x => x.escuelaIdEscuela,
                        principalTable: "Escuelas",
                        principalColumn: "IdEscuela");
                    table.ForeignKey(
                        name: "FK_Proveedores_Estados_estadoIdEstado",
                        column: x => x.estadoIdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    rolIdRol = table.Column<int>(type: "int", nullable: true),
                    IdEscuela = table.Column<int>(type: "int", nullable: false),
                    escuelaIdEscuela = table.Column<int>(type: "int", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    estadoIdEstado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Escuelas_escuelaIdEscuela",
                        column: x => x.escuelaIdEscuela,
                        principalTable: "Escuelas",
                        principalColumn: "IdEscuela");
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_estadoIdEstado",
                        column: x => x.estadoIdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado");
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_rolIdRol",
                        column: x => x.rolIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    proveedorIdProveedor = table.Column<int>(type: "int", nullable: true),
                    IdEscuela = table.Column<int>(type: "int", nullable: false),
                    escuelaIdEscuela = table.Column<int>(type: "int", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Escuelas_escuelaIdEscuela",
                        column: x => x.escuelaIdEscuela,
                        principalTable: "Escuelas",
                        principalColumn: "IdEscuela");
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores_proveedorIdProveedor",
                        column: x => x.proveedorIdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor");
                });

            migrationBuilder.CreateTable(
                name: "Bitacoras",
                columns: table => new
                {
                    IdBitacora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    usuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacoras", x => x.IdBitacora);
                    table.ForeignKey(
                        name: "FK_Bitacoras_Usuarios_usuarioIdUsuario",
                        column: x => x.usuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    tipoCedulaIdTipo = table.Column<int>(type: "int", nullable: true),
                    cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    usuarioIdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdEscuela = table.Column<int>(type: "int", nullable: false),
                    escuelaIdEscuela = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Escuelas_escuelaIdEscuela",
                        column: x => x.escuelaIdEscuela,
                        principalTable: "Escuelas",
                        principalColumn: "IdEscuela");
                    table.ForeignKey(
                        name: "FK_Empleados_TipoCedula_tipoCedulaIdTipo",
                        column: x => x.tipoCedulaIdTipo,
                        principalTable: "TipoCedula",
                        principalColumn: "IdTipo");
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_usuarioIdUsuario",
                        column: x => x.usuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "ProductoDias",
                columns: table => new
                {
                    IdProductoDia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    productoIdProducto = table.Column<int>(type: "int", nullable: true),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    vendido = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoDias", x => x.IdProductoDia);
                    table.ForeignKey(
                        name: "FK_ProductoDias_Productos_productoIdProducto",
                        column: x => x.productoIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacoras_usuarioIdUsuario",
                table: "Bitacoras",
                column: "usuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_escuelaIdEscuela",
                table: "Empleados",
                column: "escuelaIdEscuela");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_tipoCedulaIdTipo",
                table: "Empleados",
                column: "tipoCedulaIdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_usuarioIdUsuario",
                table: "Empleados",
                column: "usuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Escuelas_rolIdRol",
                table: "Escuelas",
                column: "rolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_estadoIdEstado",
                table: "Pedidos",
                column: "estadoIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoDias_productoIdProducto",
                table: "ProductoDias",
                column: "productoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_escuelaIdEscuela",
                table: "Productos",
                column: "escuelaIdEscuela");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_proveedorIdProveedor",
                table: "Productos",
                column: "proveedorIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_escuelaIdEscuela",
                table: "Proveedores",
                column: "escuelaIdEscuela");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_estadoIdEstado",
                table: "Proveedores",
                column: "estadoIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_escuelaIdEscuela",
                table: "Usuarios",
                column: "escuelaIdEscuela");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_estadoIdEstado",
                table: "Usuarios",
                column: "estadoIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_rolIdRol",
                table: "Usuarios",
                column: "rolIdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacoras");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "ProductoDias");

            migrationBuilder.DropTable(
                name: "TipoCedula");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Escuelas");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
