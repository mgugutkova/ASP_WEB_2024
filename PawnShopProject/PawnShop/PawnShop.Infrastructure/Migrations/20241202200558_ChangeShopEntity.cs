using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeShopEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Допълнително описание - не е задължително");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Име на стоката");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f3bee72-1547-4f6f-a8a2-87f90aff9233", "AQAAAAIAAYagAAAAEKNAau8GZBYfeJmWj2nMllueQW1qJI1KvqECiqxYjs3df3C1NBI7knNjLtTkOrx7sQ==", "ae17b373-43b0-4562-b445-228e3b4793a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c87558d-c1b3-4677-9067-ebc84b9fcaf5", "AQAAAAIAAYagAAAAEAVoaQQmkxtbLxD6Nxo3+cetbbuqxcVnHqjg/i6Au9pzY4B0+IBq46CwAFSvRRpWPA==", "23dcb48e-9064-4229-b23d-7501e49e4893" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dd177b1-3518-4a60-94c0-8219659e97d2", "AQAAAAIAAYagAAAAEDvPYsZV8EcOR3ig8z8mc7UlRMfcqdYnV45u7p1aoaPAulB5yD8Chyb7O1g/OF0zIw==", "892a9b7c-5be0-42e9-a593-c83648fe6028" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shop");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a7c4e9f-ed25-4532-9f2a-e1eea5f6e839", "AQAAAAIAAYagAAAAEL1TJAmT6sxEza/MR+u4IMNPhMMIeh8RkOnmjps7A+KZEE9QtkWklFgi/r1HHfD4CQ==", "7e71dd4c-e93f-4326-8834-7d99693c1d36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b86c68ec-51e3-4b3c-929d-ce46a294fc09", "AQAAAAIAAYagAAAAEIB98VSAQ+RubYAzWJpqsa5/lYQbe1nVt58IM2f27h8iqZgY7bL5q6wmCes9N4mTdg==", "84cbdf18-6298-4d4c-bf34-5709bf0df2b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "073c917f-ee1b-4335-bc65-3313cecf786f", "AQAAAAIAAYagAAAAEFfE1Dt5r7zkCthBAm6UQAQH7X0qQ7CPBYq5BNHhVsOR10tKkB2vJ+TIEJLfxvFFsA==", "62605c43-b06a-4b64-8448-4867a18c393e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc715845-7402-4960-a946-c8455d756582", "AQAAAAIAAYagAAAAEE0EJwzHJ6JTHdxTs30Jq44hw4aV+W5PD8HAY1tBCIQrr010JLu32tPwpYz0r7/ltw==", "dc8f606f-e355-4c26-ace6-af102fa7f258" });
        }
    }
}
