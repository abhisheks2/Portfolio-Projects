using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeFinance.Migrations
{
    public partial class AddExpenseLimitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseLimits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    ExpenseCategory = table.Column<string>(nullable: false),
                    ExpenseType = table.Column<string>(nullable: false),
                    Limit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseLimits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseLimits");
        }
    }
}
