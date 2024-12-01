using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgrreementStateId", "Ainterest", "ClientId", "Description", "Duration", "EndDate", "GoodName", "IsDeleted", "Price", "ReturnPrice", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1m, null, "4GB RAM, 120SSD", 10, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "лаптоп Acer", false, 200m, 201m, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ffae7662-4ff3-4698-8f36-c4e4f392da18" },
                    { 2, 2, 3m, null, "used - produced 2012", 30, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "SONY TV", false, 100m, 103m, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "5cf194c7-b26e-42ed-8efd-d98c7980373b" },
                    { 3, 5, 0m, null, "model Balkan", 30, new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike", false, 30m, 33m, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "5cf194c7-b26e-42ed-8efd-d98c7980373b" }
                });

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

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "IsDeleted", "PhoneNumber", "UserId" },
                values: new object[] { 3, "Varna,Center", false, "8888899999", "b97f29e7-1edd-4666-a8d8-8882858d7ccf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "IsDeleted", "PhoneNumber", "UserId" },
                values: new object[] { 2, "Plovdiv,Izgrev", false, "1234599999", "ffae7662-4ff3-4698-8f36-c4e4f392da18" });
        }
    }
}
