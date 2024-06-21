using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaInvestAPI.Migrations
{
    /// <inheritdoc />
    public partial class FullDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    LinkSocial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UF = table.Column<int>(type: "int", nullable: false),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileBytes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROJETOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusProjeto = table.Column<int>(type: "int", nullable: false),
                    NomeProjeto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Subtitulo = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    DescricaoProjeto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustoProjeto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Investido = table.Column<bool>(type: "bit", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CronogramaId = table.Column<int>(type: "int", nullable: false),
                    FileBytes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROJETOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PROJETOS_TB_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CRONOGRAMAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CRONOGRAMAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CRONOGRAMAS_TB_PROJETOS_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "TB_PROJETOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ATIVIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoAtividade = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StatusAtividade = table.Column<int>(type: "int", nullable: false),
                    DataInicioAtividade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTerminoAtividade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Percentual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CronogramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ATIVIDADES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ATIVIDADES_TB_CRONOGRAMAS_CronogramaId",
                        column: x => x.CronogramaId,
                        principalTable: "TB_CRONOGRAMAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "CPF", "Cidade", "DataAcesso", "Email", "FileBytes", "LinkSocial", "Nome", "PasswordHash", "PasswordSalt", "Perfil", "Sobrenome", "Telefone", "UF" },
                values: new object[] { 1, "", "", new DateTime(2024, 6, 17, 3, 25, 14, 814, DateTimeKind.Local).AddTicks(5501), "educainvest.co@gmail.com", null, "", "", new byte[] { 149, 132, 188, 101, 128, 121, 16, 58, 66, 54, 146, 248, 42, 195, 110, 187, 141, 64, 124, 151, 84, 125, 210, 74, 204, 74, 179, 192, 105, 137, 45, 163, 120, 222, 128, 172, 221, 76, 167, 252, 229, 200, 179, 185, 62, 192, 180, 143, 13, 140, 190, 133, 170, 108, 227, 154, 181, 245, 157, 30, 232, 196, 66, 237 }, new byte[] { 52, 81, 124, 191, 189, 35, 58, 15, 160, 150, 173, 52, 141, 200, 194, 88, 152, 37, 239, 76, 64, 59, 70, 13, 190, 203, 9, 97, 79, 100, 89, 244, 119, 35, 25, 23, 96, 224, 144, 13, 235, 224, 39, 62, 210, 83, 24, 170, 76, 33, 64, 59, 188, 154, 226, 0, 149, 197, 124, 231, 158, 62, 90, 13, 240, 87, 136, 26, 118, 18, 181, 205, 140, 84, 118, 219, 227, 21, 41, 222, 4, 160, 204, 117, 24, 238, 236, 198, 69, 52, 183, 130, 139, 107, 174, 220, 152, 115, 194, 182, 111, 10, 19, 139, 189, 160, 124, 70, 165, 191, 170, 40, 63, 15, 97, 34, 224, 60, 148, 249, 73, 222, 132, 109, 185, 81, 237, 188 }, 1, "", "", 6 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ATIVIDADES_CronogramaId",
                table: "TB_ATIVIDADES",
                column: "CronogramaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CRONOGRAMAS_ProjetoId",
                table: "TB_CRONOGRAMAS",
                column: "ProjetoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROJETOS_UsuarioId",
                table: "TB_PROJETOS",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ATIVIDADES");

            migrationBuilder.DropTable(
                name: "TB_CRONOGRAMAS");

            migrationBuilder.DropTable(
                name: "TB_PROJETOS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");
        }
    }
}
