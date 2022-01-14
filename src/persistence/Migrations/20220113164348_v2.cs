using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace repository.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumaber",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumaber",
                table: "Locations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "72303163-1c6f-46b7-9b0f-2488317811cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "4708ddb8-4ea9-42c5-abaa-f9a7301bf714");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "0ab78f57-052b-48bc-9cf9-4761fa9a3602");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "d802a31f-4a9d-4742-b1df-f0855ccb7129", new DateTime(2022, 1, 10, 3, 0, 5, 248, DateTimeKind.Local).AddTicks(7602), "AQAAAAEAACcQAAAAEEQCZq5v/KQC5upsL4R34AomnW9CdwwpmA6a015EaYrTmadcSSkLfVBm8B+0Lkakwg==" });
        }
    }
}
