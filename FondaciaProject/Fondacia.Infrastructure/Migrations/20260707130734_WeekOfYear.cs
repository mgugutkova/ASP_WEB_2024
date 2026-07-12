using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fondacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WeekOfYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Week",
                table: "Activities");
        }
    }
}
