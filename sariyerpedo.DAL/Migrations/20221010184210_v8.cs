using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sariyerpedo.DAL.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imageData");

            migrationBuilder.AddColumn<byte[]>(
                name: "FullscreenContent",
                table: "imageFile",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "OriginalContent",
                table: "imageFile",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "imageFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalType",
                table: "imageFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ThumbnailContent",
                table: "imageFile",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullscreenContent",
                table: "imageFile");

            migrationBuilder.DropColumn(
                name: "OriginalContent",
                table: "imageFile");

            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "imageFile");

            migrationBuilder.DropColumn(
                name: "OriginalType",
                table: "imageFile");

            migrationBuilder.DropColumn(
                name: "ThumbnailContent",
                table: "imageFile");

            migrationBuilder.CreateTable(
                name: "imageData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullscreenContent = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OriginalContent = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OriginalType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThumbnailContent = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageData", x => x.Id);
                });
        }
    }
}
