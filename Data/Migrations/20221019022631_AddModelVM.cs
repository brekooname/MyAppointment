using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAppointment.Data.Migrations
{
    public partial class AddModelVM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duriation = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<string>(type: "TEXT", nullable: true),
                    IsDoctorApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    AdminId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
