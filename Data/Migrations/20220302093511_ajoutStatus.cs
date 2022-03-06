using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetAtlas.Data.Migrations
{
    public partial class ajoutStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemandeDAmis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amis1ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amis2ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeDAmis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DemandeDAmis_AspNetUsers_Amis2ID",
                        column: x => x.Amis2ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandeDAmis_Amis2ID",
                table: "DemandeDAmis",
                column: "Amis2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandeDAmis");
        }
    }
}
