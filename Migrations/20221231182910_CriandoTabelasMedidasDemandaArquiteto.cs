using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastrolojasfullstack.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasMedidasDemandaArquiteto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Arquitetos",
            //     columns: table => new
            //     {
            //         Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //         nomeArquiteto = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         cnpjArquiteto = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         emailArquiteto = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         dataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         dataContratacao = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         dataDesligamento = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         ativo = table.Column<byte>(type: "tinyint", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Arquitetos", x => x.Id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Demandas",
            //     columns: table => new
            //     {
            //         Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //         ApelidoLoja = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ArquitetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Demandas", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Demandas_Arquitetos_ArquitetoId",
            //             column: x => x.ArquitetoId,
            //             principalTable: "Arquitetos",
            //             principalColumn: "Id");
            //     });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bandeira = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApelidoLoja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeProjeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoLoja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerfilArquitetonico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInauguracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DemandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Demandas_DemandaId",
                        column: x => x.DemandaId,
                        principalTable: "Demandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaVendas = table.Column<double>(type: "float", nullable: false),
                    areaConstruidaVendas = table.Column<double>(type: "float", nullable: false),
                    areaApoioTerreo = table.Column<double>(type: "float", nullable: false),
                    areaApoioMezanino = table.Column<double>(type: "float", nullable: false),
                    areaEstacionamentoCoberto = table.Column<double>(type: "float", nullable: false),
                    aNaoutilizadaTerreo = table.Column<double>(type: "float", nullable: false),
                    aNaoutilizadaSup = table.Column<double>(type: "float", nullable: false),
                    areaEstacionamentoDescoberto = table.Column<double>(type: "float", nullable: false),
                    aAjardinada = table.Column<double>(type: "float", nullable: false),
                    aDescobSemPiso = table.Column<double>(type: "float", nullable: false),
                    areaTerreno = table.Column<double>(type: "float", nullable: false),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    areaApoioTotal = table.Column<double>(type: "float", nullable: true),
                    areaConstrOuRef = table.Column<double>(type: "float", nullable: true),
                    aConstrTotal = table.Column<double>(type: "float", nullable: true),
                    aExternaTotal = table.Column<double>(type: "float", nullable: true),
                    areaOcupaTerreo = table.Column<double>(type: "float", nullable: true),
                    somaAreaExternaTerreo = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medidas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Demandas_ArquitetoId",
            //     table: "Demandas",
            //     column: "ArquitetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medidas_ProjetoId",
                table: "Medidas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_DemandaId",
                table: "Projetos",
                column: "DemandaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medidas");

            migrationBuilder.DropTable(
                name: "Projetos");

            // migrationBuilder.DropTable(
            //     name: "Demandas");

            // migrationBuilder.DropTable(
            //     name: "Arquitetos");
        }
    }
}
