using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class ajoutRessourcePublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Publication_AspNetUsers_MembreID",
                        column: x => x.MembreID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publication_MembreID",
                table: "Publication",
                column: "MembreID");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DemandeDAmis_AspNetUsers_Amis2ID",
                table: "DemandeDAmis");

            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.RenameColumn(
                name: "Amis2ID",
                table: "DemandeDAmis",
                newName: "Amis2Id");

            migrationBuilder.RenameIndex(
                name: "IX_DemandeDAmis_Amis2ID",
                table: "DemandeDAmis",
                newName: "IX_DemandeDAmis_Amis2Id");

            migrationBuilder.AlterColumn<string>(
                name: "Amis1ID",
                table: "DemandeDAmis",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
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

            migrationBuilder.AddForeignKey(
                name: "FK_DemandeDAmis_AspNetUsers_Amis1ID",
                table: "DemandeDAmis",
                column: "Amis1ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DemandeDAmis_AspNetUsers_Amis2Id",
                table: "DemandeDAmis",
                column: "Amis2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
