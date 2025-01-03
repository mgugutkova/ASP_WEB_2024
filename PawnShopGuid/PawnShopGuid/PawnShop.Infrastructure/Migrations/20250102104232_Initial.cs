using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgreementStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на статус")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Име на статуса")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Идентификатор на договора"),
                    GoodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Стока"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Описание"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Заложна стойност"),
                    ReturnPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Стойност за връщане"),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Срок на договора"),
                    Ainterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Лихва"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Начална дата на договора"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Крайна дата на договора"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Идентификатор на потребителя"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "SoftDeleted"),
                    AgrreementStateId = table.Column<int>(type: "int", nullable: false, comment: "Статус на договора"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agreements_AgreementStates_AgrreementStateId",
                        column: x => x.AgrreementStateId,
                        principalTable: "AgreementStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agreements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agreements_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Идентификатор на лихва"),
                    AgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Идентификатор на договора"),
                    ValueInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Стойност на лихвата"),
                    DateInterest = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата на внасяне на лихвата"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Идентификатор на потребителя"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "SoftDeleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_Agreements_AgreementId",
                        column: x => x.AgreementId,
                        principalTable: "Agreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Идентификатор на стоката в магазин"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Име на стоката"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Допълнително описание - не е задължително"),
                    AgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Идентификатор на договора"),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Цена на стоката"),
                    SoldDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Дата на продажба на стоката"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "SoftDeleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop_Agreements_AgreementId",
                        column: x => x.AgreementId,
                        principalTable: "Agreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AgreementStates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Аwaiting approval" },
                    { 2, "Approved (Active)" },
                    { 3, "Finished" },
                    { 4, "Late" },
                    { 5, "For а Shop" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5cf194c7-b26e-42ed-8efd-d98c7980373b", 0, "1f47fa9d-1583-4653-a642-f1658bb1d041", "msef@abv.bg", false, "Mary", "Seferov", false, null, "MSEF@ABV.BG", "MSEF@ABV.BG", "AQAAAAIAAYagAAAAEIl8GW0GAe1rQF8zIFP4//MBHk1Y5BgB5W8rV67yj1250V2kyk72wuuC3s6w2OE0Rg==", null, false, "5b2ea4f1-1de2-42a6-8816-d5cd67037f2c", false, "msef@abv.bg" },
                    { "70e39283-bd42-4d0a-aa2e-46d2a31c4f87", 0, "6be15968-1ff7-4eb0-98b3-ff264a994678", "guest@abv.bg", false, "Guest", "Guestov", false, null, "GUEST@ABV.BG", "GUEST@ABV.BG", "AQAAAAIAAYagAAAAEFLuqeSzKC74eoC1xdVQzSLAw62bDAwKGV+b34+TTi7kbO+x4ha1KNMUWBNNig+L0w==", null, false, "1e9c3156-ba33-4024-be93-ce7a89f13a7b", false, "guest@abv.bg" },
                    { "b97f29e7-1edd-4666-a8d8-8882858d7ccf", 0, "327e3e8f-7fe2-43ad-b6dc-763e6c65ee07", "admin@abv.bg", false, "Admin", "Boss", false, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAIAAYagAAAAENNaJEY2des0AzyDtTRI1t8w6ZZsHoKwREWSxTvDknARLirZsjEYRFXB+w2yCmlSfA==", null, false, "914dabc7-6fa3-41fb-8401-ead8f7487bf4", false, "admin@abv.bg" },
                    { "ffae7662-4ff3-4698-8f36-c4e4f392da18", 0, "f188b077-4bed-4e86-9f16-b8aeb6f3683c", "ksef@abv.bg", false, "Kalin", "Sarafov", false, null, "KSEF@ABV.BG", "KSEF@ABV.BG", "AQAAAAIAAYagAAAAENS9TIq0+JOxgASEilVEPIO85JQKbbHc4G7MlB/rr1EQsnN+hBIfKR6kQngAkQT7Jw==", null, false, "825818b9-f318-4453-a750-05e47f57c5cf", false, "ksef@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgrreementStateId", "Ainterest", "ClientId", "Description", "Duration", "EndDate", "GoodName", "IsDeleted", "Price", "ReturnPrice", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("7bee2aba-cd40-4d44-b9e0-52759e2eacd6"), 1, 1m, null, "4GB RAM, 120SSD", 10, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "лаптоп Acer", false, 200m, 201m, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ffae7662-4ff3-4698-8f36-c4e4f392da18" },
                    { new Guid("d71c98e0-c86b-4215-914e-1917e1da023e"), 5, 0m, null, "model Balkan", 30, new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike", false, 30m, 33m, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "5cf194c7-b26e-42ed-8efd-d98c7980373b" },
                    { new Guid("dca08201-5d45-46a7-8e97-7050c17b7fe9"), 2, 3m, null, "used - produced 2012", 30, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "SONY TV", false, 100m, 103m, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "5cf194c7-b26e-42ed-8efd-d98c7980373b" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "IsDeleted", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("01ead869-aa93-4c6a-a250-971e053007a5"), "Sofiq,Dianabad", false, "1234567890", "5cf194c7-b26e-42ed-8efd-d98c7980373b" },
                    { new Guid("30c83814-2a9a-412e-bb47-79b0bbe52ec5"), "Varna,Center", false, "8888899999", "b97f29e7-1edd-4666-a8d8-8882858d7ccf" },
                    { new Guid("c7872079-c1c8-45fd-937d-12e721c3d877"), "Plovdiv,Izgrev", false, "1234599999", "ffae7662-4ff3-4698-8f36-c4e4f392da18" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "AgreementId", "DateInterest", "IsDeleted", "UserId", "ValueInterest" },
                values: new object[] { new Guid("d878db1c-db65-4120-bd81-de4cb4dc34e9"), new Guid("dca08201-5d45-46a7-8e97-7050c17b7fe9"), new DateTime(2025, 1, 2, 12, 42, 31, 740, DateTimeKind.Local).AddTicks(8754), false, "5cf194c7-b26e-42ed-8efd-d98c7980373b", 3m });

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "Id", "AgreementId", "Description", "IsDeleted", "Name", "SellPrice", "SoldDate" },
                values: new object[] { new Guid("71d22cba-64a5-489c-8166-aed8dd5d5a82"), new Guid("d71c98e0-c86b-4215-914e-1917e1da023e"), "", false, "Bike", 30m, null });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_AgrreementStateId",
                table: "Agreements",
                column: "AgrreementStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_ClientId",
                table: "Agreements",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_UserId",
                table: "Agreements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PhoneNumber",
                table: "Clients",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_AgreementId",
                table: "Interests",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_UserId",
                table: "Interests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_AgreementId",
                table: "Shop",
                column: "AgreementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "AgreementStates");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
