using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioSystem.Migrations
{
    public partial class SpecificSecurities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Securities_Portfolios_PortfolioId",
                table: "Securities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Securities",
                table: "Securities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Portfolios");

            migrationBuilder.AddColumn<Guid>(
                name: "SecurityId",
                table: "Securities",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Securities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId",
                table: "Portfolios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Securities",
                table: "Securities",
                column: "SecurityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Securities_Portfolios_PortfolioId",
                table: "Securities",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Securities_Portfolios_PortfolioId",
                table: "Securities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Securities",
                table: "Securities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "SecurityId",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Portfolios");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Securities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Portfolios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Securities",
                table: "Securities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Securities_Portfolios_PortfolioId",
                table: "Securities",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
