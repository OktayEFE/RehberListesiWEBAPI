using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehberListesiWEBAPI.Migrations
{
    public partial class IletisimBilgileri_adres_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "IletisimBilgileris",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "IletisimBilgileris");
        }
    }
}
