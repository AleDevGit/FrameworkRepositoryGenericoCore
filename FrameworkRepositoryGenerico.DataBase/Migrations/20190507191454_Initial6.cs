using Microsoft.EntityFrameworkCore.Migrations;

namespace FrameworkRepositoryGenerico.DataBase.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_TipoCliente_TipoClienteId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "TipoClienteId",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_TipoCliente_TipoClienteId",
                table: "Cliente",
                column: "TipoClienteId",
                principalTable: "TipoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_TipoCliente_TipoClienteId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "TipoClienteId",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_TipoCliente_TipoClienteId",
                table: "Cliente",
                column: "TipoClienteId",
                principalTable: "TipoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
