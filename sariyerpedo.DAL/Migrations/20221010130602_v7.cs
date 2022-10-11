using Microsoft.EntityFrameworkCore.Migrations;

namespace sariyerpedo.DAL.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imageFile_treatments_TreatmentId",
                table: "imageFile");

            migrationBuilder.DropIndex(
                name: "IX_imageFile_TreatmentId",
                table: "imageFile");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "imageFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "imageFile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_imageFile_TreatmentId",
                table: "imageFile",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_imageFile_treatments_TreatmentId",
                table: "imageFile",
                column: "TreatmentId",
                principalTable: "treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
