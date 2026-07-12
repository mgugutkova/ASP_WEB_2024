using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fondacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "VacationPersonnel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "VacationPersonnel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "VacationPersonnel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "VacationPersonnel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "VacationClients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "VacationClients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "VacationClients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "VacationClients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Personnel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Personnel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "Personnel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Personnel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Locations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "FoodTypes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FoodTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "FoodTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FoodTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "AttendanceType",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AttendanceType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "AttendanceType",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AttendanceType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Ateliers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Ateliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "Ateliers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Ateliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacationPersonnel_CreatedByUserId",
                table: "VacationPersonnel",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationPersonnel_ModifiedByUserId",
                table: "VacationPersonnel",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationClients_CreatedByUserId",
                table: "VacationClients",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationClients_ModifiedByUserId",
                table: "VacationClients",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_CreatedByUserId",
                table: "Personnel",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_ModifiedByUserId",
                table: "Personnel",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CreatedByUserId",
                table: "Locations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ModifiedByUserId",
                table: "Locations",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_CreatedByUserId",
                table: "FoodTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_ModifiedByUserId",
                table: "FoodTypes",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedByUserId",
                table: "Clients",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ModifiedByUserId",
                table: "Clients",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceType_CreatedByUserId",
                table: "AttendanceType",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceType_ModifiedByUserId",
                table: "AttendanceType",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ateliers_CreatedByUserId",
                table: "Ateliers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ateliers_ModifiedByUserId",
                table: "Ateliers",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_AspNetUsers_CreatedByUserId",
                table: "Ateliers",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_AspNetUsers_ModifiedByUserId",
                table: "Ateliers",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceType_AspNetUsers_CreatedByUserId",
                table: "AttendanceType",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceType_AspNetUsers_ModifiedByUserId",
                table: "AttendanceType",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_CreatedByUserId",
                table: "Clients",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ModifiedByUserId",
                table: "Clients",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTypes_AspNetUsers_CreatedByUserId",
                table: "FoodTypes",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTypes_AspNetUsers_ModifiedByUserId",
                table: "FoodTypes",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AspNetUsers_CreatedByUserId",
                table: "Locations",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AspNetUsers_ModifiedByUserId",
                table: "Locations",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_AspNetUsers_CreatedByUserId",
                table: "Personnel",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_AspNetUsers_ModifiedByUserId",
                table: "Personnel",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VacationClients_AspNetUsers_CreatedByUserId",
                table: "VacationClients",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationClients_AspNetUsers_ModifiedByUserId",
                table: "VacationClients",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VacationPersonnel_AspNetUsers_CreatedByUserId",
                table: "VacationPersonnel",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationPersonnel_AspNetUsers_ModifiedByUserId",
                table: "VacationPersonnel",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_AspNetUsers_CreatedByUserId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_AspNetUsers_ModifiedByUserId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceType_AspNetUsers_CreatedByUserId",
                table: "AttendanceType");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceType_AspNetUsers_ModifiedByUserId",
                table: "AttendanceType");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_CreatedByUserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ModifiedByUserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodTypes_AspNetUsers_CreatedByUserId",
                table: "FoodTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodTypes_AspNetUsers_ModifiedByUserId",
                table: "FoodTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_AspNetUsers_CreatedByUserId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_AspNetUsers_ModifiedByUserId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_AspNetUsers_CreatedByUserId",
                table: "Personnel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_AspNetUsers_ModifiedByUserId",
                table: "Personnel");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationClients_AspNetUsers_CreatedByUserId",
                table: "VacationClients");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationClients_AspNetUsers_ModifiedByUserId",
                table: "VacationClients");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationPersonnel_AspNetUsers_CreatedByUserId",
                table: "VacationPersonnel");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationPersonnel_AspNetUsers_ModifiedByUserId",
                table: "VacationPersonnel");

            migrationBuilder.DropIndex(
                name: "IX_VacationPersonnel_CreatedByUserId",
                table: "VacationPersonnel");

            migrationBuilder.DropIndex(
                name: "IX_VacationPersonnel_ModifiedByUserId",
                table: "VacationPersonnel");

            migrationBuilder.DropIndex(
                name: "IX_VacationClients_CreatedByUserId",
                table: "VacationClients");

            migrationBuilder.DropIndex(
                name: "IX_VacationClients_ModifiedByUserId",
                table: "VacationClients");

            migrationBuilder.DropIndex(
                name: "IX_Personnel_CreatedByUserId",
                table: "Personnel");

            migrationBuilder.DropIndex(
                name: "IX_Personnel_ModifiedByUserId",
                table: "Personnel");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CreatedByUserId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ModifiedByUserId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_FoodTypes_CreatedByUserId",
                table: "FoodTypes");

            migrationBuilder.DropIndex(
                name: "IX_FoodTypes_ModifiedByUserId",
                table: "FoodTypes");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedByUserId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ModifiedByUserId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceType_CreatedByUserId",
                table: "AttendanceType");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceType_ModifiedByUserId",
                table: "AttendanceType");

            migrationBuilder.DropIndex(
                name: "IX_Ateliers_CreatedByUserId",
                table: "Ateliers");

            migrationBuilder.DropIndex(
                name: "IX_Ateliers_ModifiedByUserId",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "VacationPersonnel");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "VacationPersonnel");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "VacationPersonnel");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "VacationPersonnel");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "VacationClients");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "VacationClients");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "VacationClients");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "VacationClients");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "FoodTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FoodTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "FoodTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FoodTypes");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AttendanceType");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AttendanceType");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "AttendanceType");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AttendanceType");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Ateliers");
        }
    }
}
