using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace cadastro_lojas_fullstack.Models
{
    public class Medida
    {

        [Required(ErrorMessage = "O IdProjeto é Requirido")]
        public Guid idProjeto { get; set; }

        [Required(ErrorMessage = " O campo Area Vendas é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaVendas { get; set; }


        [Required(ErrorMessage = " O campo Area Construida Vendas é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaConstruidaVendas { get; set; }

        [Required(ErrorMessage = " O campo Area Construida Apoio Terreo é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaApoioTerreo { get; set; }

        [Required(ErrorMessage = " O campo Area Construida Apoio Mezanino é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaApoioMezanino { get; set; }

        [Required(ErrorMessage = " O campo Area Estacionamento Coberto é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaEstacionamentoCoberto { get; set; }

        [Required(ErrorMessage = " O campo Area Construida Vendas é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaNaoutilizadaTerreo { get; set; }

        [Required(ErrorMessage = " O campo Area Construida Vendas é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaNaoutilizadaSup { get; set; }
        [Required(ErrorMessage = " O campo Area Construida Vendas é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaEstacionamentoDescoberto { get; set; }
        [Required(ErrorMessage = " O campo Area Construida Vendas é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaAjardinada { get; set; }
        [Required(ErrorMessage = " O campo Area Construida Vendas é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaDescobSemPiso { get; set; }
        [Required(ErrorMessage = " O campo Area Construida Vendas é Requirido")]
        [Range(0.01, 1000.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public double AreaTerreno { get; set; }


        //não são inputados dados
        public double? AreaConstApoioTotal { get; set; }
        public double? AreaConstrOuRef { get; set; }
        public double? AreaConstrTotal { get; set; }
        public double? AreaExternaTotal { get; set; }
        public double? AreaOcupaTerreo { get; set; }
        public double? SomaAreaExternaTerreo { get; set; }

        public void SomaMedida(){

        AreaConstApoioTotal = AreaApoioTerreo + AreaApoioMezanino;

        AreaConstrOuRef = AreaConstruidaVendas + AreaApoioTerreo + AreaApoioMezanino + AreaEstacionamentoCoberto;

        AreaConstrTotal = AreaConstruidaVendas + AreaApoioTerreo + AreaApoioMezanino + AreaEstacionamentoCoberto + AreaNaoutilizadaTerreo +
            AreaNaoutilizadaSup;

        AreaExternaTotal = AreaEstacionamentoDescoberto + AreaAjardinada + AreaDescobSemPiso;

        AreaOcupaTerreo = AreaConstruidaVendas + AreaApoioTerreo + AreaEstacionamentoCoberto + AreaNaoutilizadaTerreo;

        SomaAreaExternaTerreo = AreaConstruidaVendas + AreaApoioTerreo + AreaEstacionamentoCoberto + AreaNaoutilizadaTerreo +
            AreaEstacionamentoDescoberto + AreaAjardinada + AreaDescobSemPiso;}

}
}
