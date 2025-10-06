using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lesson9.Migrations
{
    /// <inheritdoc />
    public partial class queryModelPrimary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParcaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parca_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "UrunParca",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    ParcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunParca", x => new { x.UrunId, x.ParcaId });
                    table.ForeignKey(
                        name: "FK_UrunParca_Parca_ParcaId",
                        column: x => x.ParcaId,
                        principalTable: "Parca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UrunParca_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parca_UrunId",
                table: "Parca",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunParca_ParcaId",
                table: "UrunParca",
                column: "ParcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrunParca");

            migrationBuilder.DropTable(
                name: "Parca");
        }
    }
}
