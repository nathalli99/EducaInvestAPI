using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaInvestAPI.Migrations
{
    /// <inheritdoc />
    public partial class Login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "TB_USUARIOS",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt", "UF" },
                values: new object[] { new DateTime(2024, 6, 23, 4, 1, 31, 579, DateTimeKind.Local).AddTicks(6852), new byte[] { 153, 182, 52, 35, 152, 194, 158, 229, 176, 141, 2, 223, 100, 11, 113, 163, 160, 253, 161, 251, 225, 166, 172, 246, 150, 233, 183, 129, 119, 118, 130, 180, 221, 141, 137, 173, 139, 214, 164, 143, 170, 124, 66, 121, 180, 177, 31, 152, 219, 38, 97, 236, 237, 172, 128, 207, 196, 233, 222, 32, 220, 55, 238, 243 }, new byte[] { 101, 239, 145, 122, 210, 96, 77, 210, 3, 167, 216, 76, 139, 134, 238, 128, 223, 53, 30, 245, 18, 196, 217, 178, 169, 77, 121, 1, 158, 154, 136, 236, 243, 208, 183, 189, 237, 85, 24, 8, 176, 134, 182, 216, 228, 196, 204, 4, 198, 57, 195, 198, 12, 54, 228, 107, 148, 28, 115, 59, 189, 199, 24, 14, 165, 108, 52, 185, 222, 104, 190, 139, 102, 172, 138, 108, 150, 221, 112, 230, 72, 186, 16, 190, 246, 24, 107, 22, 42, 10, 34, 197, 188, 128, 49, 14, 149, 144, 117, 100, 177, 59, 231, 126, 146, 139, 30, 217, 95, 207, 169, 123, 222, 29, 30, 90, 100, 223, 122, 195, 168, 103, 40, 57, 94, 91, 100, 94 }, "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UF",
                table: "TB_USUARIOS",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAcesso", "PasswordHash", "PasswordSalt", "UF" },
                values: new object[] { new DateTime(2024, 6, 23, 2, 24, 40, 320, DateTimeKind.Local).AddTicks(7569), new byte[] { 168, 145, 17, 102, 23, 12, 160, 41, 84, 66, 213, 1, 255, 129, 89, 225, 182, 217, 156, 97, 140, 86, 232, 119, 15, 129, 255, 48, 230, 177, 166, 89, 113, 92, 51, 121, 225, 204, 138, 56, 133, 181, 205, 0, 8, 182, 219, 213, 242, 68, 127, 63, 33, 195, 246, 200, 76, 94, 232, 13, 209, 92, 35, 92 }, new byte[] { 103, 49, 54, 49, 124, 43, 246, 161, 225, 228, 3, 130, 52, 14, 252, 186, 23, 251, 99, 151, 19, 69, 164, 85, 5, 218, 161, 249, 52, 234, 209, 178, 199, 64, 41, 166, 239, 169, 126, 13, 8, 195, 239, 155, 151, 227, 71, 190, 78, 105, 147, 32, 102, 232, 59, 101, 188, 170, 140, 159, 250, 191, 54, 56, 117, 124, 161, 64, 244, 184, 252, 196, 135, 78, 50, 106, 222, 154, 114, 222, 236, 107, 244, 14, 223, 104, 152, 48, 48, 51, 87, 246, 82, 211, 235, 73, 67, 203, 101, 66, 162, 216, 5, 143, 170, 12, 207, 244, 185, 88, 79, 42, 78, 109, 148, 242, 155, 145, 114, 169, 164, 138, 159, 52, 178, 17, 148, 189 }, 6 });
        }
    }
}
