using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Interests",
                type: "int",
                nullable: false,
                comment: "Идентификатор на договора",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификато на договора");

            migrationBuilder.UpdateData(
                table: "AgreementStates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Finished");

            migrationBuilder.InsertData(
                table: "AgreementStates",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "For а Shop" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5cf194c7-b26e-42ed-8efd-d98c7980373b", 0, "e501f420-614e-438d-b80b-ff26e1b3cc02", "msef@abv.bg", false, "", "", false, null, "MSEF@ABV.BG", "MSEF", "AQAAAAIAAYagAAAAEAfY3gYwgY4tGvrJAqY8mJb5fPSb3o1mJc3KX6/so3Cwh6flmKpYHwAV/E8/aSXA2Q==", null, false, "ed11ddd7-56b1-403d-aa1b-380196665f17", false, "msef" },
                    { "70e39283-bd42-4d0a-aa2e-46d2a31c4f87", 0, "a05edb99-17c8-4c4b-9e84-48c97c8d305f", "guest@abv.bg", false, "", "", false, null, "GUEST@ABV.BG", "GUEST", "AQAAAAIAAYagAAAAEDyjSyDD47kwjb3suF13OrxX2ZqTVfUI0eDstDZywPM2L3g7vVmS6Ciy2ycSxwXL6g==", null, false, "1d8c3e9e-717e-4639-8f67-85a297a3e90f", false, "guest" },
                    { "b97f29e7-1edd-4666-a8d8-8882858d7ccf", 0, "8aba4f08-8eb6-4b6d-9c86-19dbc523f8d6", "admin@abv.bg", false, "", "", false, null, "ADMIN@ABV.BG", "ADMIN", "AQAAAAIAAYagAAAAEF44Wj+ifZZmYYDwO1ptVqWDIaFV/cQsW5oiS1o7EUHuQaWBztn6Cz8tYhEgXjC/Iw==", null, false, "d77d8e75-fc26-4700-903c-e4756a90b5a4", false, "admin" },
                    { "ffae7662-4ff3-4698-8f36-c4e4f392da18", 0, "c3fe721f-bc48-475b-861b-e2772367ed71", "ksef@abv.bg", false, "", "", false, null, "KSEF@ABV.BG", "KSEF", "AQAAAAIAAYagAAAAEEuVU0QawID6E4KKaW32dv2XyaLazdHWt4kEe/x2yZSSkJA6UN82AUO+lykXkyHjaQ==", null, false, "cc233c35-06cc-4be1-ac56-b9e828fe273d", false, "ksef" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "IsDeleted", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "Sofiq,Dianabad", false, "1234567890", "5cf194c7-b26e-42ed-8efd-d98c7980373b" },
                    { 2, "Plovdiv,Izgrev", false, "1234599999", "ffae7662-4ff3-4698-8f36-c4e4f392da18" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AgreementStates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18");

            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Interests",
                type: "int",
                nullable: false,
                comment: "Идентификато на договора",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификатор на договора");

            migrationBuilder.UpdateData(
                table: "AgreementStates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Finish");
        }
    }
}
