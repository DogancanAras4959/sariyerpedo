using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sariyerpedo.DAL.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_treatments_serviceCategory_categoryId",
                table: "treatments");

            migrationBuilder.DropTable(
                name: "serviceCategory");

            migrationBuilder.DropIndex(
                name: "IX_treatments_categoryId",
                table: "treatments");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "treatments");

            migrationBuilder.DropColumn(
                name: "langTitle",
                table: "languages");

            migrationBuilder.AddColumn<string>(
                name: "langTitleEng",
                table: "languages",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "langTitleTr",
                table: "languages",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "langTitleEng",
                table: "languages");

            migrationBuilder.DropColumn(
                name: "langTitleTr",
                table: "languages");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "treatments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "langTitle",
                table: "languages",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "serviceCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_treatments_categoryId",
                table: "treatments",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_serviceCategory_categoryId",
                table: "treatments",
                column: "categoryId",
                principalTable: "serviceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
