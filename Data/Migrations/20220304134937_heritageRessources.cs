using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class heritageRessources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Ressource",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contenuLien",
                table: "Ressource",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "contenuLien",
                table: "Ressource");
        }
    }
}
