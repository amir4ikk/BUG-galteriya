using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "FullName", "Password" },
                values: new object[] { new DateTime(2024, 6, 21, 14, 16, 31, 176, DateTimeKind.Utc).AddTicks(9777), "owner@gmail.com", "Oybek Muxtaraliyev", "A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "FullName", "Password" },
                values: new object[] { new DateTime(2024, 6, 20, 11, 47, 15, 200, DateTimeKind.Utc).AddTicks(9561), "xumorahacker@gmail.com", "Saidamirxon Abrorbekov", "8a31bb92b2be0203c5ee64e322a9db1406cb02c45170c35ab5c833ec6908a473" });
        }
    }
}
