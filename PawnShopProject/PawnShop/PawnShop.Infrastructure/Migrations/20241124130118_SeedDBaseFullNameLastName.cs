using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDBaseFullNameLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ee5dd5f-0f74-4675-b346-bbd519f6481d", "Mary", "Seferov", "AQAAAAIAAYagAAAAEIHea2PvYjECTPqYndvWUkcs4r0SeH3Ffu7A43c4bbmhgmBQD5AcTfHbMaHgtpscVw==", "9548d2f4-e32c-4b63-8f0b-8e8e749c98da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb48b50-627e-4df0-91fe-3f92ebd9b8b1", "Galin", "Gogov", "AQAAAAIAAYagAAAAELYso/l1Nzrl/x8r+Va0URUHPuSCGEu0jSJTVRm5HQNB55X1JgZwmi+WyZq/uuHSOg==", "808e7fcd-a43c-4c9c-a03d-b30c479609eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "747f7a7b-150a-45f2-8bce-59774acde61e", "Boss", "Petrov", "AQAAAAIAAYagAAAAEPQfjQG9UY5/7kGaOD4C1UzhpzfNo3QE9lwpYlW6fg/+7JfSjvUGVx+5LNX5itgnbQ==", "340e8eca-b0a7-439e-9d70-b06e8be4dbd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "deae70d8-bf88-421e-a042-3da59417f2da", "Kalin", "Sarafov", "AQAAAAIAAYagAAAAEMgVNbiqsMRv0Pw5t41cXs9qHqrvcNl1/Nh9AuPB+h5n8lctzaxFhhN0lMNeePnxog==", "f6e9260e-a7bb-4fd0-a32c-dc78dc871ff1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e501f420-614e-438d-b80b-ff26e1b3cc02", "", "", "AQAAAAIAAYagAAAAEAfY3gYwgY4tGvrJAqY8mJb5fPSb3o1mJc3KX6/so3Cwh6flmKpYHwAV/E8/aSXA2Q==", "ed11ddd7-56b1-403d-aa1b-380196665f17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a05edb99-17c8-4c4b-9e84-48c97c8d305f", "", "", "AQAAAAIAAYagAAAAEDyjSyDD47kwjb3suF13OrxX2ZqTVfUI0eDstDZywPM2L3g7vVmS6Ciy2ycSxwXL6g==", "1d8c3e9e-717e-4639-8f67-85a297a3e90f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aba4f08-8eb6-4b6d-9c86-19dbc523f8d6", "", "", "AQAAAAIAAYagAAAAEF44Wj+ifZZmYYDwO1ptVqWDIaFV/cQsW5oiS1o7EUHuQaWBztn6Cz8tYhEgXjC/Iw==", "d77d8e75-fc26-4700-903c-e4756a90b5a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3fe721f-bc48-475b-861b-e2772367ed71", "", "", "AQAAAAIAAYagAAAAEEuVU0QawID6E4KKaW32dv2XyaLazdHWt4kEe/x2yZSSkJA6UN82AUO+lykXkyHjaQ==", "cc233c35-06cc-4be1-ac56-b9e828fe273d" });
        }
    }
}
