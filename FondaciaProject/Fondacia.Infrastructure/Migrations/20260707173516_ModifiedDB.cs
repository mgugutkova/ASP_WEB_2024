using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fondacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_Clients_ClientId",
                table: "Personnel");

            migrationBuilder.DropIndex(
                name: "IX_Personnel_ClientId",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Personnel");

            migrationBuilder.AddColumn<int>(
                name: "FoodTypeId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Activities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FoodTypeId",
                table: "Clients",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PersonId",
                table: "Activities",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Personnel_PersonId",
                table: "Activities",
                column: "PersonId",
                principalTable: "Personnel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_FoodTypes_FoodTypeId",
                table: "Clients",
                column: "FoodTypeId",
                principalTable: "FoodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Personnel_PersonId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_FoodTypes_FoodTypeId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_FoodTypeId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Activities_PersonId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "FoodTypeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Activities");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Personnel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_ClientId",
                table: "Personnel",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_Clients_ClientId",
                table: "Personnel",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
