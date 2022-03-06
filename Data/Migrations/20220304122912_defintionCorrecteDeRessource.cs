using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class defintionCorrecteDeRessource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {








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
                name: "Taille",
                table: "Ressource");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PublicationID1",
                table: "Ressource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublicationID2",
                table: "Ressource",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RessourceMessage_PublicationID1",
                table: "Ressource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RessourcePhotoVideo_PublicationID1",
                table: "Ressource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Taille",
                table: "Ressource",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ressource_PublicationID1",
                table: "Ressource",
                column: "PublicationID1");

            migrationBuilder.CreateIndex(
                name: "IX_Ressource_PublicationID2",
                table: "Ressource",
                column: "PublicationID2");

            migrationBuilder.CreateIndex(
                name: "IX_Ressource_RessourceMessage_PublicationID1",
                table: "Ressource",
                column: "RessourceMessage_PublicationID1");

            migrationBuilder.CreateIndex(
                name: "IX_Ressource_RessourcePhotoVideo_PublicationID1",
                table: "Ressource",
                column: "RessourcePhotoVideo_PublicationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressource_Publication_PublicationID1",
                table: "Ressource",
                column: "PublicationID1",
                principalTable: "Publication",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressource_Publication_PublicationID2",
                table: "Ressource",
                column: "PublicationID2",
                principalTable: "Publication",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ressource_Publication_RessourceMessage_PublicationID1",
                table: "Ressource",
                column: "RessourceMessage_PublicationID1",
                principalTable: "Publication",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressource_Publication_RessourcePhotoVideo_PublicationID1",
                table: "Ressource",
                column: "RessourcePhotoVideo_PublicationID1",
                principalTable: "Publication",
                principalColumn: "ID");
        }
    }
}


