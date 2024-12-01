using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67783ffa-7076-463e-b188-0adb17ca3811", "AQAAAAIAAYagAAAAEMNrS/immdxuD5rJGWpwq7s/mPcdfRL1yZF7OdXs6qEHoB0T4xFpeefnS//GNIPvlw==", "a8a40e39-835d-457e-a50c-d6669a483523" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa52ef93-043e-4786-9b02-1972b378adf9", "AQAAAAIAAYagAAAAEKjkXBvDXd3+zh9CGQbqEOe55s5M8cNgp0FPEqiGmX2RG3s63t0W1mvQzzuJ+lHCvw==", "789e73e1-25ca-4328-b848-f3b88d375c78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4803f23e-5ddf-4e28-b3ea-031cdbbbfa1d", "AQAAAAIAAYagAAAAEIf6Euj7XKQHd/UuvZxwYzOO08OSqBMpjifikVGGFfgPtjb42NBFltK929HZiGQkTQ==", "39fa6555-412a-44ef-8153-3aea81b69181" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3eeb52a-56d8-44a2-b593-8b74652df5eb", "AQAAAAIAAYagAAAAEIwtLLR9xJ7gfEXfxg9zr1It+mdcvoIKQQHRe9HjqwWM/hN1biz65XPRtTREeVD7kg==", "bed7c07d-0c4c-4406-a345-b9d959225caa" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "IsDeleted", "PhoneNumber", "UserId" },
                values: new object[] { 2, "Plovdiv,Izgrev", false, "1234599999", "ffae7662-4ff3-4698-8f36-c4e4f392da18" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc9f0d91-6c80-4d3b-bd67-58e6d9526471", "AQAAAAIAAYagAAAAEHOtKGBv6Aj5h802NcT53qCzcrycjleQOnGB8szMWS1De51PJTtLH2W/jskzQI+ssQ==", "fc919bb5-23a3-4028-96a8-f2d22fd21622" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1a4b642-4709-4e7b-8cce-31018429ad9b", "AQAAAAIAAYagAAAAEEuojGM09YFtCrwvcC6fj9ka9ynhGCPtvXVNr2UTCAe7WIkAS+v6LP96rsBVsqe7sQ==", "dbcb3ddf-80f4-4b0e-ab1e-403393a7ced7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "159f75b8-27b6-44d5-aa20-18a624f3578a", "AQAAAAIAAYagAAAAEJpSVh+WCPWj8/ZS1uEpnXJbVmUdY7ChXwsjeO/DhhOorU9Npjf63Pyr8INp6aPG0w==", "bd5bbb7e-42c5-4bb9-a46d-577be9ee14db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee444778-1eff-4074-9ab9-2b700a90b26c", "AQAAAAIAAYagAAAAEPT6WK8gm83BrcjOvyia7PLKp2rv6Yc3kYWxV+fp1cTnciPTl3eACQKWNfuaonUjzA==", "51de2845-7acb-4f8c-9883-cdf05c955501" });
        }
    }
}
