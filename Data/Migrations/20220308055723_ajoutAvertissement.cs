using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class ajoutAvertissement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avertissement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetAtlasUserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avertissement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Avertissement_AspNetUsers_NetAtlasUserID",
                        column: x => x.NetAtlasUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avertissement_NetAtlasUserID",
                table: "Avertissement",
                column: "NetAtlasUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avertissement");
        }
    }
}
