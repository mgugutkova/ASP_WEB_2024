using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldInterestInAgreementRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AInterest",
                table: "Agreements",
                newName: "Ainterest");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ainterest",
                table: "Agreements",
                newName: "AInterest");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "732adfc5-35a5-41a8-a0ea-37bc0b912706", "AQAAAAIAAYagAAAAEI6JcQw7iLIxIkTKHGYJr+VT+xMG06A75k3Ajh21dhhpWd1MVhkcuEzSYP15H/UIgg==", "78ff86c9-e955-4c67-9cf3-26e50aabe62c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17d79537-e821-4079-8ee2-206e9a0def37", "AQAAAAIAAYagAAAAEHElBRSeInyTFT7zYRugtr+dcl4pGQcjzwE7VVpPQQlFpL5G50jf0jXYZZ7szFW/Ug==", "96dbd059-924e-485e-bae4-6d23cb01d829" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a38188ed-231a-4641-a71d-cb03156bf39d", "AQAAAAIAAYagAAAAEPwpc/cxZXnoxlTLSVKbEHw++MA3Fvtn+6BhmifgTGKTGGyzbEz73emRySgirdpW1g==", "c4c18f9b-58a4-4ea9-87af-31e3df37a4b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f123c23-c8b7-478c-84d2-392964a7291f", "AQAAAAIAAYagAAAAEBqQakwjIY9jBHzZ2mJ0uHBF08oSm4cfnVW7B7rN7TJMH+jgIQqy5lErXK+N7UqY8A==", "674c8127-b205-49a3-b523-7dcf973f00ed" });
        }
    }
}
