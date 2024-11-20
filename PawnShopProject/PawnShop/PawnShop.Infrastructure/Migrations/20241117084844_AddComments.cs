using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Agreements_AgreementId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_AspNetUsers_OperatorId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Agreements_ContractId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_ContractId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Interests_OperatorId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Interests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SoldDate",
                table: "Shop",
                type: "datetime2",
                nullable: false,
                comment: "Дата на продажба на стоката",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                table: "Shop",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Цена на стоката",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Shop",
                type: "bit",
                nullable: false,
                comment: "SoftDeleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Shop",
                type: "int",
                nullable: false,
                comment: "Идентификатор на стоката в магазин",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AgreementId",
                table: "Shop",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Идентификатор на договора");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValueInterest",
                table: "Interests",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Стойност на лихвата",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Interests",
                type: "bit",
                nullable: false,
                comment: "SoftDeleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInterest",
                table: "Interests",
                type: "datetime2",
                nullable: false,
                comment: "Дата на внасяне на лихвата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Interests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Идентификато на договора",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Interests",
                type: "int",
                nullable: false,
                comment: "Идентификатор на лихва",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Interests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Идентификатор на потребителя");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AgreementStates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Име на статуса",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AgreementStates",
                type: "int",
                nullable: false,
                comment: "Идентификатор на статус",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Agreements",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Идентификатор на потребителя",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                comment: "Начална дата на договора",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnPrice",
                table: "Agreements",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Стойност за връщане",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Agreements",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Заложна стойност",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Agreements",
                type: "bit",
                nullable: false,
                comment: "SoftDeleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "GoodName",
                table: "Agreements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Стока",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                comment: "Крайна дата на договора",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Agreements",
                type: "int",
                nullable: false,
                comment: "Срок на договора",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Agreements",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Описание",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgrreementStateId",
                table: "Agreements",
                type: "int",
                nullable: false,
                comment: "Статус на договора",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Agreements",
                type: "int",
                nullable: false,
                comment: "Идентификатор на договора",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_AgreementId",
                table: "Shop",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_UserId",
                table: "Interests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Agreements_AgreementId",
                table: "Interests",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_AspNetUsers_UserId",
                table: "Interests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Agreements_AgreementId",
                table: "Shop",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Agreements_AgreementId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_AspNetUsers_UserId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Agreements_AgreementId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_AgreementId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Interests_UserId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "AgreementId",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Interests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SoldDate",
                table: "Shop",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Дата на продажба на стоката");

            migrationBuilder.AlterColumn<decimal>(
                name: "SellPrice",
                table: "Shop",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Цена на стоката");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Shop",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "SoftDeleted");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Shop",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификатор на стоката в магазин")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Shop",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValueInterest",
                table: "Interests",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Стойност на лихвата");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Interests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "SoftDeleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInterest",
                table: "Interests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Дата на внасяне на лихвата");

            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Interests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификато на договора");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Interests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификатор на лихва")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Interests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OperatorId",
                table: "Interests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AgreementStates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Име на статуса");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AgreementStates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификатор на статус")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Agreements",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Идентификатор на потребителя");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Начална дата на договора");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnPrice",
                table: "Agreements",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Стойност за връщане");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Agreements",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Заложна стойност");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Agreements",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "SoftDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "GoodName",
                table: "Agreements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Стока");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Крайна дата на договора");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Agreements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Срок на договора");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Agreements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Описание");

            migrationBuilder.AlterColumn<int>(
                name: "AgrreementStateId",
                table: "Agreements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Статус на договора");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Agreements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификатор на договора")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ContractId",
                table: "Shop",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_OperatorId",
                table: "Interests",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Agreements_AgreementId",
                table: "Interests",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_AspNetUsers_OperatorId",
                table: "Interests",
                column: "OperatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Agreements_ContractId",
                table: "Shop",
                column: "ContractId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
