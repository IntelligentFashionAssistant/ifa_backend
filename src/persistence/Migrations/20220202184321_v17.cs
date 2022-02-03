using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace repository.Migrations
{
    public partial class v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Categorys_CategoryId",
                table: "Sizes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "054bc857-8d61-43a3-bffe-92c19e151d53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "e89303bb-9e47-46aa-ba38-13ab3daf3e51");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "aa354b32-df81-4227-bc81-f58e9677e34f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "186c4b03-5d1a-415e-b23c-e129f8a1d72d", new DateTime(2022, 2, 2, 20, 43, 20, 682, DateTimeKind.Local).AddTicks(8630), "AQAAAAEAACcQAAAAELlKJB5HYV2RELInonT+JtBIbGDjJ4oQnR6scMtrj979JHQEnK0y4B9KEylMViYUaA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Categorys_CategoryId",
                table: "Sizes",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Categorys_CategoryId",
                table: "Sizes");

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
                name: "FK_Sizes_Categorys_CategoryId",
                table: "Sizes",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id");
        }
    }
}
