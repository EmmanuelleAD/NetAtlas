using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class seePendingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DemandeDAmis_AspNetUsers_Amis2ID",
                table: "DemandeDAmis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DemandeDAmis",
                table: "DemandeDAmis");

            migrationBuilder.RenameTable(
                name: "DemandeDAmis",
                newName: "NetAtlasUser");

            migrationBuilder.RenameIndex(
                name: "IX_DemandeDAmis_Amis2ID",
                table: "NetAtlasUser",
                newName: "IX_NetAtlasUser_Amis2ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetAtlasUser",
                table: "NetAtlasUser",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NetAtlasUser_AspNetUsers_Amis2ID",
                table: "NetAtlasUser",
                column: "Amis2ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
