using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addStockTempDt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock_Temp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurmentId = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock_Temp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Temp_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Temp_MeasurmentTypes_MeasurmentTypeId",
                        column: x => x.MeasurmentTypeId,
                        principalTable: "MeasurmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Temp_Measurments_MeasurmentId",
                        column: x => x.MeasurmentId,
                        principalTable: "Measurments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Temp_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Temp_ColorId",
                table: "Stock_Temp",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Temp_MeasurmentId",
                table: "Stock_Temp",
                column: "MeasurmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Temp_MeasurmentTypeId",
                table: "Stock_Temp",
                column: "MeasurmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Temp_ProductId",
                table: "Stock_Temp",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock_Temp");
        }
    }
}
