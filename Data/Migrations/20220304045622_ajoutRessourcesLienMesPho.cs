using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class ajoutRessourcesLienMesPho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contenu",
                table: "Ressource",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Ressource",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomLien",
                table: "Ressource",
                type: "nvarchar(max)",
                nullable: true);

            

            migrationBuilder.AddColumn<double>(
                name: "taille",
                table: "Ressource",
                type: "float",
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ressource_Publication_PublicationID1",
                table: "Ressource");

            migrationBuilder.DropIndex(
                name: "IX_Ressource_PublicationID1",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "Contenu",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "NomLien",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "PublicationID1",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "taille",
                table: "Ressource");
        }
    }
}
