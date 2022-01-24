using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectPrelucaAnca.Migrations
{
    public partial class TabelAngajati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumarCtr = table.Column<string>(nullable: true),
                    Nume = table.Column<string>(nullable: true),
                    Prenume = table.Column<string>(nullable: true),
                    DataNasterii = table.Column<DateTime>(nullable: false),
                    DataAngajare = table.Column<DateTime>(nullable: false),
                    Salariu = table.Column<float>(nullable: false),
                    LocalitateID = table.Column<int>(nullable: false),
                    DepartamentID = table.Column<int>(nullable: false),
                    FunctieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Angajat_Departament_DepartamentID",
                        column: x => x.DepartamentID,
                        principalTable: "Departament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Angajat_Functie_FunctieID",
                        column: x => x.FunctieID,
                        principalTable: "Functie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Angajat_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_DepartamentID",
                table: "Angajat",
                column: "DepartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_FunctieID",
                table: "Angajat",
                column: "FunctieID");

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_LocalitateID",
                table: "Angajat",
                column: "LocalitateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Angajat");
        }
    }
}
