using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullCart.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserID",
                schema: "FullCart",
                table: "Order");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.AlterColumn<long>(
                name: "UserID",
                schema: "FullCart",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                schema: "User",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserID",
                schema: "FullCart",
                table: "Order",
                column: "UserID",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserID",
                schema: "FullCart",
                table: "Order");

            migrationBuilder.DropTable(
                name: "User",
                schema: "User");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "FullCart",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserID",
                schema: "FullCart",
                table: "Order",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
