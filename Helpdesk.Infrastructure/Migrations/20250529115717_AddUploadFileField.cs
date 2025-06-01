using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUploadFileField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Requests",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Satisfaction",
                table: "Requests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestsHistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestStateId = table.Column<int>(type: "int", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_RequestsHistory_AspNetUsers_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestsHistory_RequestStates_RequestStateId",
                        column: x => x.RequestStateId,
                        principalTable: "RequestStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestsHistory_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestsHistory_ChangedById",
                table: "RequestsHistory",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsHistory_RequestId",
                table: "RequestsHistory",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsHistory_RequestStateId",
                table: "RequestsHistory",
                column: "RequestStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestsHistory");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Satisfaction",
                table: "Requests");
        }
    }
}
