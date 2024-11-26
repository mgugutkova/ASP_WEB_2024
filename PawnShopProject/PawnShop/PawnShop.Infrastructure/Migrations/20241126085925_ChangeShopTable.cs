using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeShopTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SoldDate",
                table: "Shop",
                type: "datetime2",
                nullable: true,
                comment: "Дата на продажба на стоката",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Дата на продажба на стоката");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f2d1452-38bf-4848-8a9d-90c5ba27dd68", "AQAAAAIAAYagAAAAEOXI/h22lDK8tGwLP8VsohUvp62lNVORPYiaykCI2atewyZXM9BGoXYIKoZ/cZH9Fg==", "acb5f6a4-bf60-4f11-b2eb-ca822cbbec23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c140987f-6ff0-4917-8fa1-a4df47150a20", "AQAAAAIAAYagAAAAEHHdOJkS2Dpx5O4/rGcxIVTCJpk5IrR5g4CY9vVS14WR/bWVxfU2hsYVGgJhXVD6Ow==", "0a04880c-a80a-431e-b9eb-e71606367e08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52b69b2c-9295-4107-8acd-650047ed4241", "AQAAAAIAAYagAAAAEGbjiOLigr/8TP7FQjNvaQvpgaCZTU0nJej4sccCFPOzTEDKMUNohauMgllqutH/ZQ==", "37879cf3-8994-42bc-9052-0446a677af55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd27d0bb-ea64-4ebf-afe4-1c7cb60fa8c4", "AQAAAAIAAYagAAAAED8ME2FtIhCpZE+MgN1w2SrSEHQWZGMTzDjxLikBYT2/RAIpYrhKHskJKUCOlT571w==", "9fcf90f9-ea12-4506-a9b6-51945fd79a1d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SoldDate",
                table: "Shop",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Дата на продажба на стоката",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Дата на продажба на стоката");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09ea42ee-b106-47b1-801c-b69af921e32d", "AQAAAAIAAYagAAAAEPcl+ZD0kPwEUKaxbLkWyWmONJ5LFnq27bjTyTSheTqf+luW8TMWYlU51/94qIkgdg==", "6445c9e0-1821-4a82-9541-6136689efe74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cf5f4fb-13eb-49e5-9dfe-10f7bb949e0e", "AQAAAAIAAYagAAAAEBSo0UJoSKzVIbQB79ddSG3RGVHQkEeFwp6s/yxUKkXbYmv7YVBS/kJt4Vo1QjdTxw==", "e20510d7-bfae-49c0-8fd0-577b4b3d4de4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe4209a9-45ac-4006-856f-99462daa19f7", "AQAAAAIAAYagAAAAEIXj82U1zZh2eJ4HuqWlH7jt/v/SC6zOhS0oeBsdrK9EoazTSQwhzHgTGgknoTZ3RQ==", "3229850f-6a10-44bf-9192-6b810884fe0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5ff24b1-8915-4add-9aad-7ca0361c9720", "AQAAAAIAAYagAAAAEGNvzRtXGK3MMkL4oQ0lvnHCqnyB0F7+SAT4Syx7KobOh7oXkz2Sk5bmI+N1LsfeBQ==", "1d86b894-6627-4260-9847-bca7668ca542" });
        }
    }
}
