using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrameworkRepositoryGenerico.WebAPI.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Usuario",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "Rg",
                table: "Cliente",
                newName: "Cpf_Cnpj");

            migrationBuilder.AddColumn<string>(
                name: "Ativo",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ativo",
                table: "TipoContato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ativo",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Contato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Cliente",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipoClienteId",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Regra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Ativo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Ativo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRegra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    RegraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRegra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRegra_Regra_RegraId",
                        column: x => x.RegraId,
                        principalTable: "Regra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioRegra_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TipoClienteId",
                table: "Cliente",
                column: "TipoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRegra_RegraId",
                table: "UsuarioRegra",
                column: "RegraId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRegra_UsuarioId",
                table: "UsuarioRegra",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_TipoCliente_TipoClienteId",
                table: "Cliente",
                column: "TipoClienteId",
                principalTable: "TipoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_TipoCliente_TipoClienteId",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoCliente");

            migrationBuilder.DropTable(
                name: "UsuarioRegra");

            migrationBuilder.DropTable(
                name: "Regra");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_TipoClienteId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "TipoContato");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "TipoClienteId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuario",
                newName: "senha");

            migrationBuilder.RenameColumn(
                name: "Cpf_Cnpj",
                table: "Cliente",
                newName: "Rg");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Cliente",
                nullable: true);
        }
    }
}
