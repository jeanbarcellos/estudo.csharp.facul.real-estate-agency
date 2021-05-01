using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAgency.Infra.Data.Migrations
{
    public partial class AjustementsToColumnsTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_client",
                table: "client");

            migrationBuilder.AlterColumn<string>(
                name: "social_number",
                table: "client",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "client",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "client",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "client_pk",
                table: "client",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "client_pk",
                table: "client");

            migrationBuilder.AlterColumn<string>(
                name: "social_number",
                table: "client",
                type: "varchar(128)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "client",
                type: "varchar(128)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "client",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_client",
                table: "client",
                column: "id");
        }
    }
}
