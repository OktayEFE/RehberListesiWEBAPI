using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehberListesiWEBAPI.Migrations
{
    public partial class RehberIdDIletisimIDdzeltilmesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Rehbers",
                newName: "RehberID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "IletisimBilgileris",
                newName: "IletisimID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RehberID",
                table: "Rehbers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "IletisimID",
                table: "IletisimBilgileris",
                newName: "ID");
        }
    }
}
