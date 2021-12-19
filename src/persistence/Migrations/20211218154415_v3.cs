using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace repository.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BodySizes_BodySizesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Garments_GarmentId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Properties_PropertyId",
                table: "Images");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "Images",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "GarmentId",
                table: "Images",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "Garments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "BodySizesId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Garments_StoreId",
                table: "Garments",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BodySizes_BodySizesId",
                table: "AspNetUsers",
                column: "BodySizesId",
                principalTable: "BodySizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Garments_Stores_StoreId",
                table: "Garments",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Garments_GarmentId",
                table: "Images",
                column: "GarmentId",
                principalTable: "Garments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Properties_PropertyId",
                table: "Images",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BodySizes_BodySizesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Garments_Stores_StoreId",
                table: "Garments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Garments_GarmentId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Properties_PropertyId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Garments_StoreId",
                table: "Garments");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Garments");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "Images",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GarmentId",
                table: "Images",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BodySizesId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BodySizes_BodySizesId",
                table: "AspNetUsers",
                column: "BodySizesId",
                principalTable: "BodySizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Garments_GarmentId",
                table: "Images",
                column: "GarmentId",
                principalTable: "Garments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Properties_PropertyId",
                table: "Images",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
