using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComuniQBD.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoSistemaComuniQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.CidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoCampanha",
                columns: table => new
                {
                    TipoCampanhaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCampanhaNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCampanha", x => x.TipoCampanhaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDenuncia",
                columns: table => new
                {
                    TipoDenunciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDenunciaNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDenuncia", x => x.TipoDenunciaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioSobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioApelido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioTelefone = table.Column<int>(type: "int", nullable: false),
                    UsuarioCPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCEP = table.Column<int>(type: "int", nullable: false),
                    UsuarioCidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UssuarioBairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Bairro",
                columns: table => new
                {
                    BairroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BairroNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairro", x => x.BairroId);
                    table.ForeignKey(
                        name: "FK_Bairro_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bairro_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campanha",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanhaTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampanhaMidia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampanhaDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCampanhaId = table.Column<int>(type: "int", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanha", x => x.CampanhaId);
                    table.ForeignKey(
                        name: "FK_Campanha_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campanha_TipoCampanha_TipoCampanhaId",
                        column: x => x.TipoCampanhaId,
                        principalTable: "TipoCampanha",
                        principalColumn: "TipoCampanhaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComentarioTexto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Denuncia",
                columns: table => new
                {
                    DenunciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenunciaTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DenunciaMidia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DenunciaDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDenunciaId = table.Column<int>(type: "int", nullable: false),
                    BairroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncia", x => x.DenunciaId);
                    table.ForeignKey(
                        name: "FK_Denuncia_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "BairroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denuncia_TipoDenuncia_TipoDenunciaId",
                        column: x => x.TipoDenunciaId,
                        principalTable: "TipoDenuncia",
                        principalColumn: "TipoDenunciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicacao",
                columns: table => new
                {
                    PublicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicacaoTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    BairroId = table.Column<int>(type: "int", nullable: false),
                    PublicacaoMidia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacao", x => x.PublicacaoId);
                    table.ForeignKey(
                        name: "FK_Publicacao_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "BairroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publicacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bairro_CidadeId",
                table: "Bairro",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bairro_EstadoId",
                table: "Bairro",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_CidadeId",
                table: "Campanha",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_TipoCampanhaId",
                table: "Campanha",
                column: "TipoCampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioId",
                table: "Comentario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncia_BairroId",
                table: "Denuncia",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncia_TipoDenunciaId",
                table: "Denuncia",
                column: "TipoDenunciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacao_BairroId",
                table: "Publicacao",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacao_UsuarioId",
                table: "Publicacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campanha");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Denuncia");

            migrationBuilder.DropTable(
                name: "Publicacao");

            migrationBuilder.DropTable(
                name: "TipoCampanha");

            migrationBuilder.DropTable(
                name: "TipoDenuncia");

            migrationBuilder.DropTable(
                name: "Bairro");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
