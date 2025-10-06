using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lesson9.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parca_Urunler_UrunId",
                table: "Parca");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunParca_Parca_ParcaId",
                table: "UrunParca");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunParca_Urunler_UrunId",
                table: "UrunParca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrunParca",
                table: "UrunParca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parca",
                table: "Parca");

            migrationBuilder.RenameTable(
                name: "UrunParca",
                newName: "UrunParcalar");

            migrationBuilder.RenameTable(
                name: "Parca",
                newName: "Parcalar");

            migrationBuilder.RenameIndex(
                name: "IX_UrunParca_ParcaId",
                table: "UrunParcalar",
                newName: "IX_UrunParcalar_ParcaId");

            migrationBuilder.RenameIndex(
                name: "IX_Parca_UrunId",
                table: "Parcalar",
                newName: "IX_Parcalar_UrunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrunParcalar",
                table: "UrunParcalar",
                columns: new[] { "UrunId", "ParcaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcalar",
                table: "Parcalar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcalar_Urunler_UrunId",
                table: "Parcalar",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrunParcalar_Parcalar_ParcaId",
                table: "UrunParcalar",
                column: "ParcaId",
                principalTable: "Parcalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrunParcalar_Urunler_UrunId",
                table: "UrunParcalar",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcalar_Urunler_UrunId",
                table: "Parcalar");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunParcalar_Parcalar_ParcaId",
                table: "UrunParcalar");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunParcalar_Urunler_UrunId",
                table: "UrunParcalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrunParcalar",
                table: "UrunParcalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcalar",
                table: "Parcalar");

            migrationBuilder.RenameTable(
                name: "UrunParcalar",
                newName: "UrunParca");

            migrationBuilder.RenameTable(
                name: "Parcalar",
                newName: "Parca");

            migrationBuilder.RenameIndex(
                name: "IX_UrunParcalar_ParcaId",
                table: "UrunParca",
                newName: "IX_UrunParca_ParcaId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcalar_UrunId",
                table: "Parca",
                newName: "IX_Parca_UrunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrunParca",
                table: "UrunParca",
                columns: new[] { "UrunId", "ParcaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parca",
                table: "Parca",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parca_Urunler_UrunId",
                table: "Parca",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrunParca_Parca_ParcaId",
                table: "UrunParca",
                column: "ParcaId",
                principalTable: "Parca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrunParca_Urunler_UrunId",
                table: "UrunParca",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
