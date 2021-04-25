using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class _01inicial : Migration
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
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "Date", nullable: false),
                    Juros = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    DataBaixa = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "Id", "Cpf", "DataAlteracao", "DataInclusao", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Nome" },
                values: new object[] { 1, "12345678900", null, new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 526, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, -3, 0, 0, 0)), null, 0, "Samuel de Moraes Lemes" });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "Id", "Cpf", "DataAlteracao", "DataInclusao", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Nome" },
                values: new object[] { 2, "11111111111", null, new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 532, DateTimeKind.Unspecified).AddTicks(355), new TimeSpan(0, -3, 0, 0, 0)), null, 0, "Jeremias de Moraes Lemes" });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "Id", "Cpf", "DataAlteracao", "DataInclusao", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Nome" },
                values: new object[] { 3, "22222222222", null, new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 532, DateTimeKind.Unspecified).AddTicks(518), new TimeSpan(0, -3, 0, 0, 0)), null, 0, "Patricia de Moraes Lemes" });

            migrationBuilder.InsertData(
                table: "Documentos",
                columns: new[] { "Id", "DataAlteracao", "DataInclusao", "DataVencimento", "IdPessoa", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Juros", "Multa", "Parcela", "TipoDocumento", "Valor", "idDocumentoOrigem" },
                values: new object[] { 1, null, new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 532, DateTimeKind.Unspecified).AddTicks(2535), new TimeSpan(0, -3, 0, 0, 0)), new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, 0.01m, 0.02m, 10, 1, 300m, null });

            migrationBuilder.InsertData(
                table: "Documentos",
                columns: new[] { "Id", "DataAlteracao", "DataInclusao", "DataVencimento", "IdPessoa", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Juros", "Multa", "Parcela", "TipoDocumento", "Valor", "idDocumentoOrigem" },
                values: new object[] { 5, null, new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 535, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, -3, 0, 0, 0)), new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 0, 0.01m, 0.02m, 10, 1, 500m, null });

            migrationBuilder.InsertData(
                table: "Documentos",
                columns: new[] { "Id", "DataAlteracao", "DataInclusao", "DataVencimento", "IdPessoa", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Juros", "Multa", "Parcela", "TipoDocumento", "Valor", "idDocumentoOrigem" },
                values: new object[] { 2, null, new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 535, DateTimeKind.Unspecified).AddTicks(250), new TimeSpan(0, -3, 0, 0, 0)), new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, 0.01m, 0.02m, 10, 2, 100m, 1 });

            migrationBuilder.InsertData(
                table: "Documentos",
                columns: new[] { "Id", "DataAlteracao", "DataInclusao", "DataVencimento", "IdPessoa", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Juros", "Multa", "Parcela", "TipoDocumento", "Valor", "idDocumentoOrigem" },
                values: new object[] { 3, null, new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 535, DateTimeKind.Unspecified).AddTicks(989), new TimeSpan(0, -3, 0, 0, 0)), new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, 0.01m, 0.02m, 11, 2, 100m, 1 });

            migrationBuilder.InsertData(
                table: "Documentos",
                columns: new[] { "Id", "DataAlteracao", "DataInclusao", "DataVencimento", "IdPessoa", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Juros", "Multa", "Parcela", "TipoDocumento", "Valor", "idDocumentoOrigem" },
                values: new object[] { 4, null, new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 535, DateTimeKind.Unspecified).AddTicks(1048), new TimeSpan(0, -3, 0, 0, 0)), new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, 0.01m, 0.02m, 12, 2, 100m, 1 });

            migrationBuilder.InsertData(
                table: "DocumentoBaixa",
                columns: new[] { "Id", "DataAlteracao", "DataBaixa", "DataInclusao", "IdUsuarioAlteracao", "IdUsuarioInclusao", "Valor", "ValorDesconto", "idDocumento" },
                values: new object[] { 4, null, new DateTimeOffset(new DateTime(2020, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 24, 15, 31, 17, 535, DateTimeKind.Unspecified).AddTicks(1677), new TimeSpan(0, -3, 0, 0, 0)), null, 0, 100m, 0m, 2 });

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
