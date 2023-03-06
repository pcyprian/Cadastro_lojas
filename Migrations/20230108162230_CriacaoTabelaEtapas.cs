using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastrolojasfullstack.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaEtapas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etapas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idProjeto = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    etapaProjeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoObra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parceiroSubLocacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoEstacionamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aplicacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroVagas = table.Column<int>(type: "int", nullable: true),
                    totem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    toldo = table.Column<int>(type: "int", nullable: true),
                    elementoHorizontal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    led = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dimmer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arCondicionado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etapas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id");
                });


            migrationBuilder.CreateIndex(
                name: "IX_Etapas_ProjetoId",
                table: "Etapas",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etapas");
        }
    }
}
