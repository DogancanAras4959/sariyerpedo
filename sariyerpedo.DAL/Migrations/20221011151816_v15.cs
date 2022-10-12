using Microsoft.EntityFrameworkCore.Migrations;

namespace sariyerpedo.DAL.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "treatments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "treatments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
