using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifyStockdts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Colors_ColorId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Measurments_MeasurmentId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Products_ProductId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_Colors_ColorId",
                table: "Stock_Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_Measurments_MeasurmentId",
                table: "Stock_Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_Products_ProductId",
                table: "Stock_Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Temp_Colors_ColorId",
                table: "Stock_Temp");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Temp_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Temp");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Temp_Measurments_MeasurmentId",
                table: "Stock_Temp");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Temp_Products_ProductId",
                table: "Stock_Temp");

            migrationBuilder.AlterColumn<long>(
                name: "StockId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                table: "Stock_Temp",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Qty",
                table: "Stock_Temp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "Stock_Temp",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentTypeId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ColorId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                table: "Stock_Logs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Qty",
                table: "Stock_Logs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "Stock_Logs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentTypeId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ColorId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                table: "Stock",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Qty",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "Stock",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentTypeId",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentId",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ColorId",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Colors_ColorId",
                table: "Stock",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Measurments_MeasurmentId",
                table: "Stock",
                column: "MeasurmentId",
                principalTable: "Measurments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Products_ProductId",
                table: "Stock",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_Colors_ColorId",
                table: "Stock_Logs",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Logs",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_Measurments_MeasurmentId",
                table: "Stock_Logs",
                column: "MeasurmentId",
                principalTable: "Measurments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_Products_ProductId",
                table: "Stock_Logs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Temp_Colors_ColorId",
                table: "Stock_Temp",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Temp_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Temp",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Temp_Measurments_MeasurmentId",
                table: "Stock_Temp",
                column: "MeasurmentId",
                principalTable: "Measurments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Temp_Products_ProductId",
                table: "Stock_Temp",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Colors_ColorId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Measurments_MeasurmentId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Products_ProductId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_Colors_ColorId",
                table: "Stock_Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_Measurments_MeasurmentId",
                table: "Stock_Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Logs_Products_ProductId",
                table: "Stock_Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Temp_Colors_ColorId",
                table: "Stock_Temp");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Temp_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Temp");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Temp_Measurments_MeasurmentId",
                table: "Stock_Temp");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Temp_Products_ProductId",
                table: "Stock_Temp");

            migrationBuilder.AlterColumn<long>(
                name: "StockId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                table: "Stock_Temp",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "Qty",
                table: "Stock_Temp",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "Stock_Temp",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentTypeId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ColorId",
                table: "Stock_Temp",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                table: "Stock_Logs",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "Qty",
                table: "Stock_Logs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "Stock_Logs",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentTypeId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ColorId",
                table: "Stock_Logs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                table: "Stock",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "Qty",
                table: "Stock",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "Stock",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Stock",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentTypeId",
                table: "Stock",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentId",
                table: "Stock",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ColorId",
                table: "Stock",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Colors_ColorId",
                table: "Stock",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Measurments_MeasurmentId",
                table: "Stock",
                column: "MeasurmentId",
                principalTable: "Measurments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Products_ProductId",
                table: "Stock",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_Colors_ColorId",
                table: "Stock_Logs",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Logs",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_Measurments_MeasurmentId",
                table: "Stock_Logs",
                column: "MeasurmentId",
                principalTable: "Measurments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Logs_Products_ProductId",
                table: "Stock_Logs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Temp_Colors_ColorId",
                table: "Stock_Temp",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Temp_MeasurmentTypes_MeasurmentTypeId",
                table: "Stock_Temp",
                column: "MeasurmentTypeId",
                principalTable: "MeasurmentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Temp_Measurments_MeasurmentId",
                table: "Stock_Temp",
                column: "MeasurmentId",
                principalTable: "Measurments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Temp_Products_ProductId",
                table: "Stock_Temp",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
