using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sariyerpedo.DAL.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_treatments_languages_LangId",
                table: "treatments");

            migrationBuilder.CreateTable(
                name: "langCountry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    langTitle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_langCountry", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_langCountry_LangId",
                table: "treatments",
                column: "LangId",
                principalTable: "langCountry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_treatments_langCountry_LangId",
                table: "treatments");

            migrationBuilder.DropTable(
                name: "langCountry");

            migrationBuilder.AddForeignKey(
                name: "FK_treatments_languages_LangId",
                table: "treatments",
                column: "LangId",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
