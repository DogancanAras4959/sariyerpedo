using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sariyerpedo.DAL.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "treatments");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "treatments");

            migrationBuilder.CreateTable(
                name: "iamgeFileTreatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    folder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ThumbnailContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FullscreenContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageNo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iamgeFileTreatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iamgeFileTreatment_treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_iamgeFileTreatment_TreatmentId",
                table: "iamgeFileTreatment",
                column: "TreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "iamgeFileTreatment");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "treatments",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "treatments",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");
        }
    }
}
