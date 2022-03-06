using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class modificationDemandesAmis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
              name: "IX_DemandeDAmis_Amis2ID",
              table: "DemandeDAmis");


            migrationBuilder.AlterColumn<string>(
                name: "Amis1ID",
                table: "DemandeDAmis",
                type: "nvarchar(450)",
                nullable: false,
                 defaultValue: ""
                );

            migrationBuilder.AlterColumn<string>(
                name: "Amis2ID",
                table: "DemandeDAmis",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeDAmis_Amis1ID",
                table: "DemandeDAmis",
                column: "Amis1ID");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeDAmis_Amis2ID",
                table: "DemandeDAmis",
                column: "Amis2ID");




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DemandeDAmis_AspNetUsers_Amis1ID",
                table: "DemandeDAmis");

            migrationBuilder.DropForeignKey(
                name: "FK_DemandeDAmis_AspNetUsers_Amis2Id",
                table: "DemandeDAmis");

            migrationBuilder.DropForeignKey(
                name: "FK_DemandeDAmis_AspNetUsers_Amis2ID",
                table: "DemandeDAmis");

            migrationBuilder.DropIndex(
                name: "IX_DemandeDAmis_Amis1ID",
                table: "DemandeDAmis");

            migrationBuilder.DropIndex(
                name: "IX_DemandeDAmis_Amis2ID",
                table: "DemandeDAmis");

            migrationBuilder.DropColumn(
                name: "Amis2ID",
                table: "DemandeDAmis");

            migrationBuilder.RenameColumn(
                name: "Amis2Id",
                table: "DemandeDAmis",
                newName: "Amis2ID");

            migrationBuilder.RenameIndex(
                name: "IX_DemandeDAmis_Amis2Id",
                table: "DemandeDAmis",
                newName: "IX_DemandeDAmis_Amis2ID");

            migrationBuilder.AlterColumn<string>(
                name: "Amis1ID",
                table: "DemandeDAmis",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_DemandeDAmis_AspNetUsers_Amis2ID",
                table: "DemandeDAmis",
                column: "Amis2ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}


