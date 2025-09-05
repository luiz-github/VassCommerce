using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vassCommerce.Migrations
{
    /// <inheritdoc />
    public partial class v07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_EnderecoId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Cliente");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Endereco",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_ClienteId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Endereco");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_EnderecoId",
                table: "Cliente",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");
        }
    }
}
