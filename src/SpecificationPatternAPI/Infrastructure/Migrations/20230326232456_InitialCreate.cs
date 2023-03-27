using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpecificationPatternAPI.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IsCompanyAdministrator = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[] { 1, true, "Coca-Cola" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[] { 2, true, "Pepsi" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CompanyId", "IsCompanyAdministrator", "Name" },
                values: new object[] { 1, true, null, false, "Rafael" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CompanyId", "IsCompanyAdministrator", "Name" },
                values: new object[,]
                {
                    { 2, true, 1, true, "Bruno" },
                    { 3, true, 1, false, "Fernando" },
                    { 4, true, 2, false, "Daniel" },
                    { 5, true, 1, false, "Gabriel" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Active", "FinancialValue", "UserId" },
                values: new object[] { 1, true, 20000m, 3 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Active", "FinancialValue", "UserId" },
                values: new object[] { 2, true, 15000m, 4 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Active", "FinancialValue", "UserId" },
                values: new object[] { 3, true, 5000m, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
