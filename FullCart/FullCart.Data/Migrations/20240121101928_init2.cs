using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullCart.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Item_ItemtId",
                schema: "FullCart",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                schema: "FullCart",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_OrderId",
                schema: "FullCart",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "ItemtId",
                schema: "FullCart",
                table: "OrderItem",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ItemtId",
                schema: "FullCart",
                table: "OrderItem",
                newName: "IX_OrderItem_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                schema: "FullCart",
                table: "OrderItem",
                columns: new[] { "OrderId", "ItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Item_ItemId",
                schema: "FullCart",
                table: "OrderItem",
                column: "ItemId",
                principalSchema: "FullCart",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Item_ItemId",
                schema: "FullCart",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                schema: "FullCart",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                schema: "FullCart",
                table: "OrderItem",
                newName: "ItemtId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ItemId",
                schema: "FullCart",
                table: "OrderItem",
                newName: "IX_OrderItem_ItemtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                schema: "FullCart",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "FullCart",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Item_ItemtId",
                schema: "FullCart",
                table: "OrderItem",
                column: "ItemtId",
                principalSchema: "FullCart",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
