using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_potreba.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TryUpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HashPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Toilets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Toilets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Toilets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Toilets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Toilets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Toilets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Toilets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Toilets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Toilets_AuthorId",
                table: "Toilets",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toilets_Users_AuthorId",
                table: "Toilets",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toilets_Users_AuthorId",
                table: "Toilets");

            migrationBuilder.DropIndex(
                name: "IX_Toilets_AuthorId",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HashPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Toilets");
        }
    }
}
