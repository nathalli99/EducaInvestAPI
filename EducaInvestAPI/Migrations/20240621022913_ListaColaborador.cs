using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaInvestAPI.Migrations
{
    /// <inheritdoc />
    public partial class ListaColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "TB_USUARIOS",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt", "ProjetoId" },
                values: new object[] { new DateTime(2024, 6, 20, 23, 29, 13, 501, DateTimeKind.Local).AddTicks(2764), new byte[] { 29, 40, 52, 4, 222, 153, 139, 233, 228, 238, 29, 152, 16, 25, 119, 156, 73, 170, 56, 241, 156, 110, 225, 234, 26, 17, 244, 40, 251, 19, 129, 210, 180, 40, 170, 253, 90, 48, 213, 109, 136, 166, 214, 83, 59, 113, 117, 251, 176, 193, 11, 0, 54, 215, 104, 114, 246, 165, 166, 250, 176, 87, 47, 243 }, new byte[] { 101, 250, 147, 93, 141, 220, 229, 249, 197, 168, 200, 82, 32, 130, 246, 110, 154, 247, 58, 139, 56, 223, 142, 125, 130, 36, 237, 165, 77, 236, 168, 102, 147, 15, 215, 139, 209, 20, 253, 92, 25, 28, 71, 38, 201, 65, 57, 145, 150, 60, 58, 53, 104, 240, 130, 7, 95, 230, 94, 20, 50, 165, 109, 185, 93, 253, 144, 64, 22, 42, 23, 35, 18, 21, 226, 32, 158, 169, 173, 230, 232, 52, 152, 90, 38, 98, 62, 89, 82, 52, 242, 141, 2, 97, 43, 38, 73, 254, 154, 32, 254, 192, 140, 175, 78, 20, 137, 213, 24, 78, 118, 192, 45, 112, 114, 94, 233, 81, 204, 3, 64, 51, 53, 167, 103, 178, 131, 196 }, null });

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_ProjetoId",
                table: "TB_USUARIOS",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_TB_PROJETOS_ProjetoId",
                table: "TB_USUARIOS",
                column: "ProjetoId",
                principalTable: "TB_PROJETOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_TB_PROJETOS_ProjetoId",
                table: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_USUARIOS_ProjetoId",
                table: "TB_USUARIOS");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "TB_USUARIOS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 6, 20, 23, 6, 50, 677, DateTimeKind.Local).AddTicks(4358), new byte[] { 1, 130, 113, 126, 210, 206, 196, 151, 35, 248, 28, 73, 169, 209, 59, 38, 184, 152, 46, 80, 212, 188, 155, 120, 185, 189, 251, 139, 52, 184, 207, 169, 47, 182, 162, 171, 49, 172, 124, 252, 215, 151, 205, 59, 18, 49, 15, 72, 29, 135, 139, 95, 61, 18, 4, 27, 114, 104, 94, 168, 191, 113, 202, 65 }, new byte[] { 132, 23, 63, 15, 237, 93, 92, 128, 137, 232, 173, 206, 227, 86, 42, 209, 251, 120, 101, 168, 45, 16, 113, 217, 102, 153, 91, 18, 93, 75, 234, 31, 83, 234, 86, 57, 228, 34, 12, 56, 17, 25, 85, 9, 173, 40, 245, 223, 175, 157, 185, 172, 38, 113, 243, 235, 18, 190, 142, 42, 242, 54, 95, 236, 81, 69, 44, 67, 217, 81, 221, 187, 3, 86, 49, 234, 25, 43, 101, 34, 131, 20, 241, 8, 66, 98, 86, 56, 28, 211, 201, 183, 189, 209, 178, 133, 221, 252, 105, 121, 216, 28, 177, 116, 1, 3, 40, 2, 234, 224, 75, 148, 190, 43, 252, 33, 62, 222, 244, 192, 98, 155, 12, 67, 145, 120, 46, 38 } });
        }
    }
}
