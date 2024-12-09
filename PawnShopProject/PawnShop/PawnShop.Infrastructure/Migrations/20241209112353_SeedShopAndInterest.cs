using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedShopAndInterest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "991a28ac-100c-446f-b5af-05863503b3c1", "AQAAAAIAAYagAAAAEBcKVMXujcxy5vFUTQjr+8p+6NPuz8KEv/wGlpAtHv9phLa9pOaoXCzGPALHG4uCmw==", "7b603337-8c9a-43dc-ac6b-40af8dd33e29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8b15449-1ee4-4bc6-8ecc-da3ffceb88af", "Guest", "Guestov", "AQAAAAIAAYagAAAAEFTyY8204vFqL+BudtrJxVUuQPR4LP8ASTjwjeGD7e+JEhmxpY+OhyPJt/6Tow4ljg==", "b1b7d921-6248-4675-b600-bf335416a487" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6619cddc-2ac3-4159-95a0-16e882c09c26", "Admin", "Boss", "AQAAAAIAAYagAAAAEHms12wB+pYTS/zRvxwMc4wUZ61T08H+sFaYm0RFZU7DGln6fKeLTdclCOHl1wfm9w==", "bb0c6705-efc4-4030-b8dc-f9f0f56786ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c44a3711-5a83-454f-afe3-f1003dc832c3", "AQAAAAIAAYagAAAAEDL1jfHL4jt7ywULGGnSby1tcDGmsaPYdWIfoVuc6vWX0PfNB50iF1XfJd9Jb5ytIw==", "feb66144-b950-44af-b9ce-220b3df38da4" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "AgreementId", "DateInterest", "IsDeleted", "UserId", "ValueInterest" },
                values: new object[] { 1, 2, new DateTime(2024, 12, 9, 13, 23, 52, 267, DateTimeKind.Local).AddTicks(8761), false, "5cf194c7-b26e-42ed-8efd-d98c7980373b", 3m });

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "Id", "AgreementId", "Description", "IsDeleted", "Name", "SellPrice", "SoldDate" },
                values: new object[] { 1, 3, "", false, "Bike", 30m, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26a5f28d-8c42-435c-995d-a06d6d00bfff", "AQAAAAIAAYagAAAAEHdlYigU3kVmLVDd5oyFnokozHVh9OX42Wt96QCSKja3kVkIOY80mOR0E93Hm4JNJw==", "f1eb407c-1b8b-4598-8588-a21064a75b53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f3bee72-1547-4f6f-a8a2-87f90aff9233", "Galin", "Gogov", "AQAAAAIAAYagAAAAEKNAau8GZBYfeJmWj2nMllueQW1qJI1KvqECiqxYjs3df3C1NBI7knNjLtTkOrx7sQ==", "ae17b373-43b0-4562-b445-228e3b4793a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c87558d-c1b3-4677-9067-ebc84b9fcaf5", "Boss", "Petrov", "AQAAAAIAAYagAAAAEAVoaQQmkxtbLxD6Nxo3+cetbbuqxcVnHqjg/i6Au9pzY4B0+IBq46CwAFSvRRpWPA==", "23dcb48e-9064-4229-b23d-7501e49e4893" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dd177b1-3518-4a60-94c0-8219659e97d2", "AQAAAAIAAYagAAAAEDvPYsZV8EcOR3ig8z8mc7UlRMfcqdYnV45u7p1aoaPAulB5yD8Chyb7O1g/OF0zIw==", "892a9b7c-5be0-42e9-a593-c83648fe6028" });
        }
    }
}
