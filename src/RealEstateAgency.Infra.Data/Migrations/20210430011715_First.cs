using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAgency.Infra.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    social_number = table.Column<string>(type: "varchar(128)", maxLength: 11, nullable: false),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 100, nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
