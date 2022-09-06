using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_posgrest.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visiting_Disciplines_DisciplineId",
                table: "Visiting");

            migrationBuilder.DropIndex(
                name: "IX_Visiting_DisciplineId",
                table: "Visiting");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Visiting");

            migrationBuilder.DropColumn(
                name: "VisionId",
                table: "Visiting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "Visiting",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VisionId",
                table: "Visiting",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Visiting_DisciplineId",
                table: "Visiting",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visiting_Disciplines_DisciplineId",
                table: "Visiting",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");
        }
    }
}
