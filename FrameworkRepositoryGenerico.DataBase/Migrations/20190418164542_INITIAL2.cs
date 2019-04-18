using Microsoft.EntityFrameworkCore.Migrations;

namespace FrameworkRepositoryGenerico.DataBase.Migrations
{
    public partial class INITIAL2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_idCliente",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "_idTipoTelefone",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "_idCliente",
                table: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_idCliente",
                table: "Telefone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_idTipoTelefone",
                table: "Telefone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_idCliente",
                table: "Endereco",
                nullable: false,
                defaultValue: 0);
        }
    }
}
