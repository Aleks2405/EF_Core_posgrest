using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_posgrest.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DateOfVisitId",
                table: "Disciplines",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdKey",
                table: "Disciplines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_DateOfVisitId",
                table: "Disciplines",
                column: "DateOfVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Visiting_DateOfVisitId",
                table: "Disciplines",
                column: "DateOfVisitId",
                principalTable: "Visiting",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Visiting_DateOfVisitId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_DateOfVisitId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "DateOfVisitId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "IdKey",
                table: "Disciplines");
        }
    }
}
