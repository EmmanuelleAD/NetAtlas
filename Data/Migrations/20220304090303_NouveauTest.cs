using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class NouveauTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_Ressource_Publication_RessourceMessage_PublicationID1",
               table: "Ressource");

            migrationBuilder.DropForeignKey(
                name: "FK_Ressource_Publication_RessourcePhotoVideo_PublicationID1",
                table: "Ressource");

            migrationBuilder.DropIndex(
                name: "IX_Ressource_RessourceMessage_PublicationID1",
                table: "Ressource");

            migrationBuilder.DropIndex(
                name: "IX_Ressource_RessourcePhotoVideo_PublicationID1",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "RessourceMessage_PublicationID1",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "RessourcePhotoVideo_PublicationID1",
                table: "Ressource");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ressource_Publication_PublicationID2",
                table: "Ressource");

            migrationBuilder.DropIndex(
                name: "IX_Ressource_PublicationID2",
                table: "Ressource");

            migrationBuilder.DropColumn(
                name: "PublicationID2",
                table: "Ressource");
        }
    }
}
