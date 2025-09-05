using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vassCommerce.Migrations
{
    /// <inheritdoc />
    public partial class v05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "TEXT",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Cliente");
        }
    }
}
