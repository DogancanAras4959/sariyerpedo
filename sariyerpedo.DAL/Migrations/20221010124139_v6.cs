using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sariyerpedo.DAL.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "sliders");

            migrationBuilder.CreateTable(
                name: "imageData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OriginalType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OriginalContent = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: true),
                    ThumbnailContent = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: true),
                    FullscreenContent = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "imageFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    folder = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    SliderId = table.Column<int>(type: "int", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imageFile_sliders_SliderId",
                        column: x => x.SliderId,
                        principalTable: "sliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_imageFile_treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_imageFile_SliderId",
                table: "imageFile",
                column: "SliderId");

            migrationBuilder.CreateIndex(
                name: "IX_imageFile_TreatmentId",
                table: "imageFile",
                column: "TreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imageData");

            migrationBuilder.DropTable(
                name: "imageFile");

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "sliders",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);
        }
    }
}
