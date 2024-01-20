using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullCart.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserID",
                schema: "FullCart",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "FullCart",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "FullCart",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LMD",
                schema: "FullCart",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "FullCart",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LMD",
                schema: "FullCart",
                table: "Item",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "FullCart",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LMD",
                schema: "FullCart",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "FullCart",
                table: "Brand",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LMD",
                schema: "FullCart",
                table: "Brand",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserID",
                schema: "FullCart",
                table: "Order",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserID",
                schema: "FullCart",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "FullCart",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LMD",
                schema: "FullCart",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "FullCart",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "LMD",
                schema: "FullCart",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "FullCart",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "LMD",
                schema: "FullCart",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "FullCart",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "LMD",
                schema: "FullCart",
                table: "Brand");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "FullCart",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserID",
                schema: "FullCart",
                table: "Order",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
