using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace repository.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HEX",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "cffd802c-7c2d-4737-8414-5c128674975f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "8ed24e9f-9d83-4b4f-ae05-3bad367b8158");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "179c8cf5-3c01-4117-b2cf-6d642ae96190");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "f5384d4d-779c-49d1-ba7d-ce8503a4f37c", new DateTime(2022, 1, 15, 3, 39, 58, 226, DateTimeKind.Local).AddTicks(6182), "AQAAAAEAACcQAAAAEIzV7epA3/O6x4kZC5pFsirVteAjfMtqMKRDOEDiSTFoccHu3QcBudCJyu/gNkEkmg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HEX",
                table: "Colors");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "f28f83f3-8ec7-4adb-8039-d18bbbf84f88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "23321d65-12fa-45d2-b151-b0b9738b0f36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "d5757276-3c2b-4d92-aa28-c20e3c52446b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "6db85941-46a8-4b03-a8c6-cfd152a96bc2", new DateTime(2022, 1, 13, 18, 43, 45, 396, DateTimeKind.Local).AddTicks(3532), "AQAAAAEAACcQAAAAEOA+FzMpPUW0zYnm2AW6Zl6n2pw5EAexSi8Ybxd6gUM4paOyAmmsEfB0ZAeay5z6jQ==" });
        }
    }
}
