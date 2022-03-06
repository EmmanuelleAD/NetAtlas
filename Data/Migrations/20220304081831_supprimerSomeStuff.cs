using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class supprimerSomeStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Ressource_RessourceMessage_PublicationID1",
                table: "Ressource",
                column: "RessourceMessage_PublicationID1");

            migrationBuilder.CreateIndex(
                name: "IX_Ressource_RessourcePhotoVideo_PublicationID1",
                table: "Ressource",
                column: "RessourcePhotoVideo_PublicationID1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
