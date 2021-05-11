using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAgency.Infra.Data.Migrations
{
    public partial class SetDoublePropertiesInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "property",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sale_value = table.Column<decimal>(type: "float", nullable: false),
                    client_id = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<int>(type: "integer", nullable: false),
                    number_of_bedrooms = table.Column<int>(type: "integer", nullable: true),
                    number_of_bathrooms = table.Column<int>(type: "integer", nullable: true),
                    number_of_garage = table.Column<int>(type: "integer", nullable: true),
                    has_elevator = table.Column<bool>(type: "boolean", nullable: true),
                    floor = table.Column<int>(type: "integer", nullable: true),
                    has_furtine = table.Column<bool>(type: "boolean", nullable: true),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    on_a_corner = table.Column<bool>(type: "boolean", nullable: true),
                    width = table.Column<decimal>(type: "float", nullable: true),
                    height = table.Column<decimal>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("property_pk", x => x.id);
                    table.ForeignKey(
                        name: "property_client_id_fk",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "property_client_id_ix",
                table: "property",
                column: "client_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "property");
        }
    }
}
