using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace repository.Migrations
{
    public partial class v16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Garments_GarmentId",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "98294833-81b5-4490-aaa6-70b24e6e99d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "165a38fd-9efb-475c-af9f-01d36797901d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "0154bfc8-1f88-49d4-9af3-bde38bb62484");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "f6916bf8-835c-4c58-986b-6dd7f3718cc3", new DateTime(2022, 1, 26, 22, 51, 30, 276, DateTimeKind.Local).AddTicks(2737), "AQAAAAEAACcQAAAAEFfNZTrHZmAzXTc6rSEOXZbmDCk7bo3jtYbVp9Q8JjV4cQ82t+tDwng4/8dVgcnEGA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Garments_GarmentId",
                table: "Images",
                column: "GarmentId",
                principalTable: "Garments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Garments_GarmentId",
                table: "Images");

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
                name: "FK_Images_Garments_GarmentId",
                table: "Images",
                column: "GarmentId",
                principalTable: "Garments",
                principalColumn: "Id");
        }
    }
}
