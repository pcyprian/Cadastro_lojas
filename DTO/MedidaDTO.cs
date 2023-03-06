using System.ComponentModel.DataAnnotations;

namespace cadastro_lojas_fullstack.DTO
{
    public class MedidaDto
    {
        
        public Guid? Id { get; set; }
        public double AreaVendas { get; set; }
        public double areaConstruidaVendas { get; set; }
        public double areaApoioTerreo { get; set; }
        public double areaApoioMezanino { get; set; }
        public double areaEstacionamentoCoberto { get; set; }
        public double aNaoutilizadaTerreo { get; set; }
        public double aNaoutilizadaSup { get; set; }
        public double areaEstacionamentoDescoberto { get; set; }
        public double aAjardinada { get; set; }
        public double aDescobSemPiso { get; set; }
        public double areaTerreno { get; set; }
       
        public ProjetoDto Projeto { get; set; }
        [Required]
        public Guid ProjetoId { get; set; }

        //não são inputados dados
        public double? areaApoioTotal { get; set; }
        public double? areaConstrOuRef { get; set; }
        public double? aConstrTotal { get; set; }
        public double? aExternaTotal { get; set; }
        public double? areaOcupaTerreo { get; set; }
        public double? somaAreaExternaTerreo { get; set; }


        public void SomaMedidaDTO()
        {

            areaApoioTotal = areaApoioTerreo + areaApoioMezanino;

            areaConstrOuRef = areaConstruidaVendas + areaApoioTerreo + areaApoioMezanino + areaEstacionamentoCoberto;

            aConstrTotal = areaConstruidaVendas + areaApoioTerreo + areaApoioMezanino + areaEstacionamentoCoberto + aNaoutilizadaTerreo +
                aNaoutilizadaSup;

            aExternaTotal = areaEstacionamentoDescoberto + aAjardinada + aDescobSemPiso;

            areaOcupaTerreo = areaConstruidaVendas + areaApoioTerreo + areaEstacionamentoCoberto + aNaoutilizadaTerreo;

            somaAreaExternaTerreo = areaConstruidaVendas + areaApoioTerreo + areaEstacionamentoCoberto + aNaoutilizadaTerreo +
                areaEstacionamentoDescoberto + aAjardinada + aDescobSemPiso;
        }

    }


}

