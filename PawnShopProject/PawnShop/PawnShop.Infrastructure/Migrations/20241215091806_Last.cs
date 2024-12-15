using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51d9c528-8957-4707-b9d9-a4c42be4cd17", "AQAAAAIAAYagAAAAEDnhAVg5H6MeA/M0wwLnSrAYutwB5MPvKd9gFsrjNY3Bxh3hmcREEPmPsPrWnr23Fw==", "ce98089f-8fba-499f-baca-9ff1926849de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8eac0a79-4168-48ce-9732-e07a8ea5f7d7", "AQAAAAIAAYagAAAAEPEAaptNCaaOJVmY48MpYR/gE/TY4y99wM7s2drZ4fVHjrk0DTIwL42CUWZYL/cBfQ==", "1eeb87b7-9e04-4b30-b271-c8188c961f04", "guest@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12c84679-3617-4abf-819a-b41659aa2cfd", "AQAAAAIAAYagAAAAEPHOC1wA6h6LTJ6cF1VPltlNSmGZ/cpjesyaZTI65FGj/Xgpjd0IGo0IzNffd1Sg7A==", "c9af236f-6e8f-41a7-b8f9-44794e741ae3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc78c98f-6f2a-4ee1-87e2-0bd762dfde68", "AQAAAAIAAYagAAAAELeVLpgsjygZO395r1ElhSnkVYJIyejnHo+qvZwyGkYty5v0zJdlLf+MaAsyD3kFPw==", "71fc607e-d56d-45de-8959-4f16a93eb97e" });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateInterest",
                value: new DateTime(2024, 12, 15, 11, 18, 5, 146, DateTimeKind.Local).AddTicks(535));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d8b15449-1ee4-4bc6-8ecc-da3ffceb88af", "AQAAAAIAAYagAAAAEFTyY8204vFqL+BudtrJxVUuQPR4LP8ASTjwjeGD7e+JEhmxpY+OhyPJt/6Tow4ljg==", "b1b7d921-6248-4675-b600-bf335416a487", "guest.abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6619cddc-2ac3-4159-95a0-16e882c09c26", "AQAAAAIAAYagAAAAEHms12wB+pYTS/zRvxwMc4wUZ61T08H+sFaYm0RFZU7DGln6fKeLTdclCOHl1wfm9w==", "bb0c6705-efc4-4030-b8dc-f9f0f56786ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c44a3711-5a83-454f-afe3-f1003dc832c3", "AQAAAAIAAYagAAAAEDL1jfHL4jt7ywULGGnSby1tcDGmsaPYdWIfoVuc6vWX0PfNB50iF1XfJd9Jb5ytIw==", "feb66144-b950-44af-b9ce-220b3df38da4" });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateInterest",
                value: new DateTime(2024, 12, 9, 13, 23, 52, 267, DateTimeKind.Local).AddTicks(8761));
        }
    }
}
