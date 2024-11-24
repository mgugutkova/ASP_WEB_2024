using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldInterestInAgreement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AInterest",
                table: "Agreements",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Лихва");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AInterest",
                table: "Agreements");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ee5dd5f-0f74-4675-b346-bbd519f6481d", "AQAAAAIAAYagAAAAEIHea2PvYjECTPqYndvWUkcs4r0SeH3Ffu7A43c4bbmhgmBQD5AcTfHbMaHgtpscVw==", "9548d2f4-e32c-4b63-8f0b-8e8e749c98da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb48b50-627e-4df0-91fe-3f92ebd9b8b1", "AQAAAAIAAYagAAAAELYso/l1Nzrl/x8r+Va0URUHPuSCGEu0jSJTVRm5HQNB55X1JgZwmi+WyZq/uuHSOg==", "808e7fcd-a43c-4c9c-a03d-b30c479609eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "747f7a7b-150a-45f2-8bce-59774acde61e", "AQAAAAIAAYagAAAAEPQfjQG9UY5/7kGaOD4C1UzhpzfNo3QE9lwpYlW6fg/+7JfSjvUGVx+5LNX5itgnbQ==", "340e8eca-b0a7-439e-9d70-b06e8be4dbd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "deae70d8-bf88-421e-a042-3da59417f2da", "AQAAAAIAAYagAAAAEMgVNbiqsMRv0Pw5t41cXs9qHqrvcNl1/Nh9AuPB+h5n8lctzaxFhhN0lMNeePnxog==", "f6e9260e-a7bb-4fd0-a32c-dc78dc871ff1" });
        }
    }
}
