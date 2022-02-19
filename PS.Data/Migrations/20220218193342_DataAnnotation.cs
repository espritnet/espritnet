using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class DataAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersId",
                table: "ProductProvider");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Providers",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "ProvidersId",
                table: "ProductProvider",
                newName: "ProvidersKey");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProvider_ProvidersId",
                table: "ProductProvider",
                newName: "IX_ProductProvider_ProvidersKey");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersKey",
                table: "ProductProvider",
                column: "ProvidersKey",
                principalTable: "Providers",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersKey",
                table: "ProductProvider");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Providers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProvidersKey",
                table: "ProductProvider",
                newName: "ProvidersId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProvider_ProvidersKey",
                table: "ProductProvider",
                newName: "IX_ProductProvider_ProvidersId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersId",
                table: "ProductProvider",
                column: "ProvidersId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
