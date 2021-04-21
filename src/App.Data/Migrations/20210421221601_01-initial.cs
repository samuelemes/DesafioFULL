using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class _01initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdUsuarioInclusao = table.Column<int>(type: "int", nullable: false),
                    DataAlteracao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IdUsuarioAlteracao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDocumentoOrigem = table.Column<int>(type: "int", nullable: true),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "Date", nullable: false),
                    Juros = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Parcela = table.Column<int>(type: "int", nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdUsuarioInclusao = table.Column<int>(type: "int", nullable: false),
                    DataAlteracao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IdUsuarioAlteracao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Documentos_idDocumentoOrigem",
                        column: x => x.idDocumentoOrigem,
                        principalTable: "Documentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documentos_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoBaixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDocumento = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdUsuarioInclusao = table.Column<int>(type: "int", nullable: false),
                    DataAlteracao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IdUsuarioAlteracao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoBaixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoBaixa_Documentos_idDocumento",
                        column: x => x.idDocumento,
                        principalTable: "Documentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoBaixa_idDocumento",
                table: "DocumentoBaixa",
                column: "idDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_idDocumentoOrigem",
                table: "Documentos",
                column: "idDocumentoOrigem");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_IdPessoa",
                table: "Documentos",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentoBaixa");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
