using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAppointment.Migrations
{
    public partial class AddPartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PartNumber = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PartDescription = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    NumberInStock = table.Column<byte>(type: "INTEGER", nullable: false),
                    PartPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");
        }
    }
}
