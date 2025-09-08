using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vassCommerce.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitularId",
                table: "Cartao",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImagemSimboloUrl = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_TitularId",
                table: "Cartao",
                column: "TitularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartao_Cliente_TitularId",
                table: "Cartao",
                column: "TitularId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartao_Cliente_TitularId",
                table: "Cartao");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Cartao_TitularId",
                table: "Cartao");

            migrationBuilder.DropColumn(
                name: "TitularId",
                table: "Cartao");
        }
    }
}
