using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace repository.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGarment_AspNetUsers_GarmentId",
                table: "UserGarment");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "fa4ebf03-7c92-4655-b670-14ab75bed2f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "a5a95235-b902-450f-9ee6-e0cab43f5fb3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "a7515c39-cdd3-4b67-ae16-1e54efd38c20");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "c3bc7117-469f-47b0-9e4c-34d0271c882b", new DateTime(2022, 1, 26, 20, 26, 37, 132, DateTimeKind.Local).AddTicks(3789), "AQAAAAEAACcQAAAAEPWDhf1ic/sBnMKuY5fsFYX4/XlhScoSYDFpEarZBcUdj70sQJ5Es0g6G7XQ4+WAGQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGarment_AspNetUsers_GarmentId",
                table: "UserGarment",
                column: "GarmentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGarment_AspNetUsers_GarmentId",
                table: "UserGarment");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "848f5b55-b112-49cb-9afc-76bf37a3607e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "61564743-3e3f-46b4-96fa-baa9c97d805b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "8c4cb6ce-8a05-48b0-9042-6aa958e226b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "c11d222d-b70f-46cc-a98c-da92aba1fd83", new DateTime(2022, 1, 20, 22, 43, 38, 499, DateTimeKind.Local).AddTicks(2127), "AQAAAAEAACcQAAAAEAiCQLviV2KPYtD1iUTpaQgxuy+hDeWPlsylajmreVhI4pvxwk5dPuQ0ZSNRxVpT0A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGarment_AspNetUsers_GarmentId",
                table: "UserGarment",
                column: "GarmentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
