using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastrolojasfullstack.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquitetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomeArquiteto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpjArquiteto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailArquiteto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dataContratacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dataDesligamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquitetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demandas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApelidoLoja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArquitetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demandas_Arquitetos_ArquitetoId",
                        column: x => x.ArquitetoId,
                        principalTable: "Arquitetos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demandas_ArquitetoId",
                table: "Demandas",
                column: "ArquitetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demandas");

            migrationBuilder.DropTable(
                name: "Arquitetos");
        }
    }
}
