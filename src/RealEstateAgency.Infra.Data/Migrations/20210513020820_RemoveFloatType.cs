using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAgency.Infra.Data.Migrations
{
    public partial class RemoveFloatType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "width",
                table: "property",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "sale_value",
                table: "property",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "height",
                table: "property",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "width",
                table: "property",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "sale_value",
                table: "property",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "height",
                table: "property",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }
    }
}
