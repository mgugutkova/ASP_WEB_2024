using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserNaME : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "7409d076-bf30-4bf6-ac8c-93519e823f7b", "MSEF@ABV.BG", "AQAAAAIAAYagAAAAEDZ3rajkMttnqxrWIU8R694+cnzNdH0y3p3ZsqiWAVSCxPCWhPH1rUiXrMQVTLD9Rg==", "43894bf3-3be8-4913-b3cd-46742ebcc0ad", "msef@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "384ca770-4b0e-4307-b739-427a6fcf01a8", "GUEST@ABV.BG", "AQAAAAIAAYagAAAAEHp/7zSdw3DQWF436SDlesnIrROEdhHHXr9v4UlXEYrRZlf08LmIRUt0/OujAVtuWw==", "362879c6-a622-4418-8525-89b85c39d929" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0e538d75-08ff-432e-96c9-9d229f0f1cd7", "ADMIN@ABV.BG", "AQAAAAIAAYagAAAAENVHjTZLBleUhAsB0JFzyTEq2qcxeXeAUp9LG+csy4cFK/A+24UpzTvo4DkhMEWmmQ==", "13b17c4b-5419-4152-aeae-cb907830f4bb", "admin@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a6e83641-9ac4-4213-bca1-124d11cf34df", "KSEF@ABV.BG", "AQAAAAIAAYagAAAAEJyeC5EiSbnlF2TJaYM8Y5vYSvNhUPB/jAwDnOHI9UYPLLOYKrwEpFuYmrEvzEJ6Kw==", "07de8ef7-0986-4302-8b1c-b36596539c29", "ksef@abv.bg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "67783ffa-7076-463e-b188-0adb17ca3811", "MSEF", "AQAAAAIAAYagAAAAEMNrS/immdxuD5rJGWpwq7s/mPcdfRL1yZF7OdXs6qEHoB0T4xFpeefnS//GNIPvlw==", "a8a40e39-835d-457e-a50c-d6669a483523", "msef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa52ef93-043e-4786-9b02-1972b378adf9", "GUEST", "AQAAAAIAAYagAAAAEKjkXBvDXd3+zh9CGQbqEOe55s5M8cNgp0FPEqiGmX2RG3s63t0W1mvQzzuJ+lHCvw==", "789e73e1-25ca-4328-b848-f3b88d375c78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4803f23e-5ddf-4e28-b3ea-031cdbbbfa1d", "ADMIN", "AQAAAAIAAYagAAAAEIf6Euj7XKQHd/UuvZxwYzOO08OSqBMpjifikVGGFfgPtjb42NBFltK929HZiGQkTQ==", "39fa6555-412a-44ef-8153-3aea81b69181", "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f3eeb52a-56d8-44a2-b593-8b74652df5eb", "KSEF", "AQAAAAIAAYagAAAAEIwtLLR9xJ7gfEXfxg9zr1It+mdcvoIKQQHRe9HjqwWM/hN1biz65XPRtTREeVD7kg==", "bed7c07d-0c4c-4406-a345-b9d959225caa", "ksef" });
        }
    }
}
