using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementTypes",
                columns: table => new
                {
                    ElementTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementTypes", x => x.ElementTypeId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    WindowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WindowName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.WindowId);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ElementTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.ElementId);
                    table.ForeignKey(
                        name: "FK_Elements_ElementTypes_ElementTypeId",
                        column: x => x.ElementTypeId,
                        principalTable: "ElementTypes",
                        principalColumn: "ElementTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WindowElements",
                columns: table => new
                {
                    WindowElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WindowId = table.Column<int>(type: "int", nullable: false),
                    ElementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowElements", x => x.WindowElementId);
                    table.ForeignKey(
                        name: "FK_WindowElements_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WindowElements_Windows_WindowId",
                        column: x => x.WindowId,
                        principalTable: "Windows",
                        principalColumn: "WindowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderWindows",
                columns: table => new
                {
                    OrderWindowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    WindowId = table.Column<int>(type: "int", nullable: false),
                    WindowQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWindows", x => x.OrderWindowId);
                    table.ForeignKey(
                        name: "FK_OrderWindows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderWindows_Windows_WindowId",
                        column: x => x.WindowId,
                        principalTable: "Windows",
                        principalColumn: "WindowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "Description", "ElementTypeName" },
                values: new object[,]
                {
                    { 1, "Door type Elements", "Doors" },
                    { 2, "Window type Elements", "Windows" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "StateName" },
                values: new object[,]
                {
                    { 1, "NY" },
                    { 2, "CA" }
                });

            migrationBuilder.InsertData(
                table: "Windows",
                columns: new[] { "WindowId", "WindowName" },
                values: new object[,]
                {
                    { 1, "A51" },
                    { 2, "C Zone 5" },
                    { 3, "GLB" },
                    { 4, "OHF" }
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "ElementId", "ElementTypeId", "Height", "Width" },
                values: new object[,]
                {
                    { 1, 1, 1850, 1200 },
                    { 2, 2, 1850, 800 },
                    { 3, 2, 1850, 700 },
                    { 4, 2, 2000, 1500 },
                    { 5, 1, 2200, 1400 },
                    { 6, 2, 2200, 600 },
                    { 7, 2, 2000, 1500 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderName", "StateId" },
                values: new object[,]
                {
                    { 1, "New York Building 1", 1 },
                    { 2, "California Hotel AJK", 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderWindows",
                columns: new[] { "OrderWindowId", "OrderId", "WindowId", "WindowQuantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 4 },
                    { 2, 1, 2, 2 },
                    { 3, 2, 3, 3 },
                    { 4, 2, 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "WindowElements",
                columns: new[] { "WindowElementId", "ElementId", "WindowId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 4 },
                    { 8, 7, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ElementTypeId",
                table: "Elements",
                column: "ElementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StateId",
                table: "Orders",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWindows_OrderId",
                table: "OrderWindows",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWindows_WindowId",
                table: "OrderWindows",
                column: "WindowId");

            migrationBuilder.CreateIndex(
                name: "IX_WindowElements_ElementId",
                table: "WindowElements",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_WindowElements_WindowId",
                table: "WindowElements",
                column: "WindowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderWindows");

            migrationBuilder.DropTable(
                name: "WindowElements");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "ElementTypes");
        }
    }
}
