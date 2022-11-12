using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehberListesiWEBAPI.Migrations
{
    public partial class EntityPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_IletisimBilgileris_RehberID",
                table: "IletisimBilgileris",
                column: "RehberID");

            migrationBuilder.AddForeignKey(
                name: "FK_IletisimBilgileris_Rehbers_RehberID",
                table: "IletisimBilgileris",
                column: "RehberID",
                principalTable: "Rehbers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IletisimBilgileris_Rehbers_RehberID",
                table: "IletisimBilgileris");

            migrationBuilder.DropIndex(
                name: "IX_IletisimBilgileris_RehberID",
                table: "IletisimBilgileris");
        }
    }
}
