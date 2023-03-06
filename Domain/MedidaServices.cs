using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Infra;
using cadastro_lojas_fullstack.Models;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_lojas_fullstack.Domain
{
    public class MedidaServices
    {
        public IEnumerable<Medida> GetAllMedida()
        {
            var medidarepo = new MedidaRepository();
            IEnumerable<MedidaDto> medidadto;

            return ListMedidaDtoToListMedida(medidadto = medidarepo.GetAllMedida());

        }
        public bool InsertMedida(Medida medida)
        {
            var medidaDomain = new MedidaRepository();
            Guid idMedida = Guid.NewGuid();
            var medidas = medidaDomain.InsertMedida(ConvertMedidaToMedidaDTO(medida, idMedida));
            return medidas;

        }
        public void UpdateMedida(Medida medida, Guid id)
        {
            var medidaDomain = new MedidaRepository();
          //  Guid idMedida = medidaDomain.GetIdMedidaPorIdProjeto(medida.idProjeto);
            medidaDomain.UpdateMedida(ConvertMedidaToMedidaDTO(medida, id));
        }
        public void DeleteMedida(Guid idMedida)
        {
            var medidaDomain = new MedidaRepository();
            medidaDomain.DeleteMedida(idMedida);
        }

        public Medida GetMedidaId(Guid idMedida) {

            var medidaRepository = new MedidaRepository();
            var medidadto = medidaRepository.RecuperarMedidaById(idMedida);

            return ConvertMedidaDtoToMedida(medidadto);
        }

        public Medida ConvertMedidaDtoToMedida(MedidaDto medidadto)
        {
            var medida = new Medida();
            medida.idProjeto = (Guid)medidadto.ProjetoId;
            medida.AreaVendas = medidadto.AreaVendas;
            medida.AreaConstruidaVendas = medidadto.areaConstruidaVendas;
            medida.AreaApoioTerreo = medidadto.areaApoioTerreo;
            medida.AreaApoioMezanino = medidadto.areaApoioMezanino;
            medida.AreaEstacionamentoCoberto = medidadto.areaEstacionamentoCoberto;
            medida.AreaNaoutilizadaTerreo = medidadto.aNaoutilizadaTerreo;
            medida.AreaNaoutilizadaSup = medidadto.aNaoutilizadaSup;
            medida.AreaEstacionamentoDescoberto = medidadto.areaEstacionamentoDescoberto;
            medida.AreaAjardinada = medidadto.aAjardinada;
            medida.AreaDescobSemPiso = medidadto.aDescobSemPiso;
            medida.AreaTerreno = medidadto.areaTerreno;
            medida.AreaConstApoioTotal = medidadto.areaApoioTotal;
            medida.AreaConstrOuRef = medidadto.areaConstrOuRef;
            medida.AreaConstrTotal = medidadto.aConstrTotal;
            medida.AreaExternaTotal = medidadto.aExternaTotal;
            medida.AreaOcupaTerreo = medidadto.areaOcupaTerreo;
            medida.SomaAreaExternaTerreo = medidadto.somaAreaExternaTerreo;
            
            return medida;
        }

        public MedidaDto ConvertMedidaToMedidaDTO(Medida medida, Guid idMedida)
        {
            medida.SomaMedida();
            var medidaDto = new MedidaDto {
                ProjetoId = medida.idProjeto,
                Id = idMedida,
                AreaVendas = medida.AreaVendas,
                areaConstruidaVendas = medida.AreaConstruidaVendas,
                areaApoioTerreo = medida.AreaApoioTerreo,
                areaApoioMezanino = medida.AreaApoioMezanino,
                areaEstacionamentoCoberto = medida.AreaEstacionamentoCoberto,
                aNaoutilizadaTerreo = medida.AreaNaoutilizadaTerreo,
                aNaoutilizadaSup = medida.AreaNaoutilizadaSup,
                areaEstacionamentoDescoberto = medida.AreaEstacionamentoDescoberto,
                aAjardinada = medida.AreaAjardinada,
                aDescobSemPiso = medida.AreaDescobSemPiso,
                areaTerreno = medida.AreaTerreno,
                areaApoioTotal = medida.AreaConstApoioTotal,
                areaConstrOuRef = medida.AreaConstrOuRef,
                aConstrTotal = medida.AreaConstrTotal,
                aExternaTotal = medida.AreaExternaTotal,
                areaOcupaTerreo = medida.AreaOcupaTerreo,
                somaAreaExternaTerreo = medida.SomaAreaExternaTerreo
            };
            return medidaDto;
        }


        public IEnumerable<Medida> ListMedidaDtoToListMedida(IEnumerable<MedidaDto> colection)
        {

            var medidaconvertida = new Medida();
            var listaconvertida = new List<Medida>();
            foreach (MedidaDto medidadto in colection)
            {
                medidaconvertida.idProjeto = (Guid)medidadto.ProjetoId;
                medidaconvertida.AreaVendas = medidadto.AreaVendas;
                medidaconvertida.AreaConstruidaVendas = medidadto.areaConstruidaVendas;
                medidaconvertida.AreaApoioTerreo = medidadto.areaApoioTerreo;
                medidaconvertida.AreaApoioMezanino = medidadto.areaApoioMezanino;
                medidaconvertida.AreaEstacionamentoCoberto = medidadto.areaEstacionamentoCoberto;
                medidaconvertida.AreaNaoutilizadaTerreo = medidadto.aNaoutilizadaTerreo;
                medidaconvertida.AreaNaoutilizadaSup = medidadto.aNaoutilizadaSup;
                medidaconvertida.AreaEstacionamentoDescoberto = medidadto.areaEstacionamentoDescoberto;
                medidaconvertida.AreaAjardinada = medidadto.aAjardinada;
                medidaconvertida.AreaDescobSemPiso = medidadto.aDescobSemPiso;
                medidaconvertida.AreaTerreno = medidadto.areaTerreno;
                medidaconvertida.AreaConstApoioTotal = medidadto.areaApoioTotal;
                medidaconvertida.AreaConstrOuRef = medidadto.areaConstrOuRef;
                medidaconvertida.AreaConstrTotal = medidadto.aConstrTotal;
                medidaconvertida.AreaExternaTotal = medidadto.aExternaTotal;
                medidaconvertida.AreaOcupaTerreo = medidadto.areaOcupaTerreo;
                medidaconvertida.SomaAreaExternaTerreo = medidadto.somaAreaExternaTerreo;

                listaconvertida.Add(medidaconvertida);
            }
            return listaconvertida;
        }


        public Guid GetIdMedidaByIdProjeto(Guid idProjeto)
        {
            var medidaDomain = new MedidaRepository();
            return medidaDomain.GetIdMedidaPorIdProjeto(idProjeto);
        }
    }
    }
 

