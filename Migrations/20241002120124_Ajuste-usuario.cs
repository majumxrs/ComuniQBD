using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComuniQBD.Migrations
{
    /// <inheritdoc />
    public partial class Ajusteusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPerfilId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoPerfilId",
                table: "Usuario",
                column: "TipoPerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoPerfil_TipoPerfilId",
                table: "Usuario",
                column: "TipoPerfilId",
                principalTable: "TipoPerfil",
                principalColumn: "TipoPerfilId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoPerfil_TipoPerfilId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_TipoPerfilId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TipoPerfilId",
                table: "Usuario");
        }
    }
}
