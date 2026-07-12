using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fondacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhotoField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePhoto",
                table: "Personnel",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoContentType",
                table: "Personnel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Clients",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoContentType",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Clients");
        }
    }
}
