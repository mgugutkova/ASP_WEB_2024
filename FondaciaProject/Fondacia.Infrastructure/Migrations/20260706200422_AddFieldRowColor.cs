using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fondacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldRowColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RowColor",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowColor",
                table: "Activities");
        }
    }
}
