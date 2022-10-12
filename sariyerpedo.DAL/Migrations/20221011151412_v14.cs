using Microsoft.EntityFrameworkCore.Migrations;

namespace sariyerpedo.DAL.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_iamgeFileTreatment_treatments_TreatmentId",
                table: "iamgeFileTreatment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_iamgeFileTreatment",
                table: "iamgeFileTreatment");

            migrationBuilder.RenameTable(
                name: "iamgeFileTreatment",
                newName: "imageFileTreatment");

            migrationBuilder.RenameIndex(
                name: "IX_iamgeFileTreatment_TreatmentId",
                table: "imageFileTreatment",
                newName: "IX_imageFileTreatment_TreatmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_imageFileTreatment",
                table: "imageFileTreatment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_imageFileTreatment_treatments_TreatmentId",
                table: "imageFileTreatment",
                column: "TreatmentId",
                principalTable: "treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imageFileTreatment_treatments_TreatmentId",
                table: "imageFileTreatment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_imageFileTreatment",
                table: "imageFileTreatment");

            migrationBuilder.RenameTable(
                name: "imageFileTreatment",
                newName: "iamgeFileTreatment");

            migrationBuilder.RenameIndex(
                name: "IX_imageFileTreatment_TreatmentId",
                table: "iamgeFileTreatment",
                newName: "IX_iamgeFileTreatment_TreatmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_iamgeFileTreatment",
                table: "iamgeFileTreatment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_iamgeFileTreatment_treatments_TreatmentId",
                table: "iamgeFileTreatment",
                column: "TreatmentId",
                principalTable: "treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
