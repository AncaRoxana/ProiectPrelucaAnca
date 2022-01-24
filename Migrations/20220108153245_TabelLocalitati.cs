using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectPrelucaAnca.Migrations
{
    public partial class TabelLocalitati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localitate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true),
                    JudetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localitate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Localitate_Judet_JudetID",
                        column: x => x.JudetID,
                        principalTable: "Judet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localitate_JudetID",
                table: "Localitate",
                column: "JudetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localitate");
        }
    }
}
