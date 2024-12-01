using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserNameGuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b86c68ec-51e3-4b3c-929d-ce46a294fc09", "AQAAAAIAAYagAAAAEIB98VSAQ+RubYAzWJpqsa5/lYQbe1nVt58IM2f27h8iqZgY7bL5q6wmCes9N4mTdg==", "84cbdf18-6298-4d4c-bf34-5709bf0df2b5", "guest.abv.bg" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7409d076-bf30-4bf6-ac8c-93519e823f7b", "AQAAAAIAAYagAAAAEDZ3rajkMttnqxrWIU8R694+cnzNdH0y3p3ZsqiWAVSCxPCWhPH1rUiXrMQVTLD9Rg==", "43894bf3-3be8-4913-b3cd-46742ebcc0ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "384ca770-4b0e-4307-b739-427a6fcf01a8", "AQAAAAIAAYagAAAAEHp/7zSdw3DQWF436SDlesnIrROEdhHHXr9v4UlXEYrRZlf08LmIRUt0/OujAVtuWw==", "362879c6-a622-4418-8525-89b85c39d929", "guest" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e538d75-08ff-432e-96c9-9d229f0f1cd7", "AQAAAAIAAYagAAAAENVHjTZLBleUhAsB0JFzyTEq2qcxeXeAUp9LG+csy4cFK/A+24UpzTvo4DkhMEWmmQ==", "13b17c4b-5419-4152-aeae-cb907830f4bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6e83641-9ac4-4213-bca1-124d11cf34df", "AQAAAAIAAYagAAAAEJyeC5EiSbnlF2TJaYM8Y5vYSvNhUPB/jAwDnOHI9UYPLLOYKrwEpFuYmrEvzEJ6Kw==", "07de8ef7-0986-4302-8b1c-b36596539c29" });
        }
    }
}
