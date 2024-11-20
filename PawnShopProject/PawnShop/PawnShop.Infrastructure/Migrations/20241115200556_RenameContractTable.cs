using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameContractTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Contracts_ContractId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Contracts_ContractId",
                table: "Shop");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ContractStates");

            migrationBuilder.DropIndex(
                name: "IX_Interests_ContractId",
                table: "Interests");

            migrationBuilder.AddColumn<int>(
                name: "AgreementId",
                table: "Interests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgreementStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AgrreementStateId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agreements_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_AgreementId",
                table: "Interests",
                column: "AgreementId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Agreements_AgreementId",
                table: "Interests",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Agreements_ContractId",
                table: "Shop",
                column: "ContractId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Agreements_AgreementId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Agreements_ContractId",
                table: "Shop");

            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "AgreementStates");

            migrationBuilder.DropIndex(
                name: "IX_Interests_AgreementId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "AgreementId",
                table: "Interests");

            migrationBuilder.CreateTable(
                name: "ContractStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ContractStateId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractStates_ContractStateId",
                        column: x => x.ContractStateId,
                        principalTable: "ContractStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_ContractId",
                table: "Interests",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractStateId",
                table: "Contracts",
                column: "ContractStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_OperatorId",
                table: "Contracts",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Contracts_ContractId",
                table: "Interests",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Contracts_ContractId",
                table: "Shop",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
