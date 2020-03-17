using Microsoft.EntityFrameworkCore.Migrations;

namespace _2doParcial.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Llamadas",
                columns: table => new
                {
                    LlamadaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamadas", x => x.LlamadaId);
                });

            migrationBuilder.CreateTable(
                name: "LlamadasDetalle",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Problema = table.Column<string>(nullable: true),
                    Solucion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadasDetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_LlamadasDetalle_Llamadas_id",
                        column: x => x.id,
                        principalTable: "Llamadas",
                        principalColumn: "LlamadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Llamadas",
                columns: new[] { "LlamadaId", "Descripcion" },
                values: new object[] { 1, "Saliente" });

            migrationBuilder.InsertData(
                table: "Llamadas",
                columns: new[] { "LlamadaId", "Descripcion" },
                values: new object[] { 2, "Entrante" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlamadasDetalle");

            migrationBuilder.DropTable(
                name: "Llamadas");
        }
    }
}
