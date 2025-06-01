using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOperatorAndManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Operators_OperatorId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.AlterColumn<string>(
                name: "OperatorId",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ManagerId",
                table: "Requests",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_ManagerId",
                table: "Requests",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_OperatorId",
                table: "Requests",
                column: "OperatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_ManagerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_OperatorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ManagerId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperatorId",
                table: "Requests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operators_UserId",
                table: "Operators",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Operators_OperatorId",
                table: "Requests",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");
        }
    }
}
