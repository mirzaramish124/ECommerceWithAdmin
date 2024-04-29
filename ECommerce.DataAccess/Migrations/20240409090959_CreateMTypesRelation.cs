using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateMTypesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MType",
                table: "Stock_Logs");

            migrationBuilder.DropColumn(
                name: "MType",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "MType",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "MeasurmentTypeId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MeasurmentTypeId",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MeasurmentTypeId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Logs_MeasurmentTypeId",
                table: "Stock_Logs",
                column: "MeasurmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_MeasurmentTypeId",
                table: "Stock",
                column: "MeasurmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MeasurmentTypeId",
                table: "Products",
                column: "MeasurmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MeasurmentTypes_MeasurmentTypeId",
                table: "Products",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Logs",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MeasurmentTypes_MeasurmentTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Logs");

            migrationBuilder.DropIndex(
                name: "IX_Stock_Logs_MeasurmentTypeId",
                table: "Stock_Logs");

            migrationBuilder.DropIndex(
                name: "IX_Stock_MeasurmentTypeId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Products_MeasurmentTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MeasurmentTypeId",
                table: "Stock_Logs");

            migrationBuilder.DropColumn(
                name: "MeasurmentTypeId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "MeasurmentTypeId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "MType",
                table: "Stock_Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MType",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
