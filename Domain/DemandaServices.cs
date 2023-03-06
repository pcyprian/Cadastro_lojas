using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Infra;
using cadastro_lojas_fullstack.Models;
using Dapper;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace cadastro_lojas_fullstack.Domain
{
    internal class DemandaServices
    {
        public DemandaServices()
        {
        }

        public Object GetDemandaById(Guid id)
        {
            var demandaRepository = new DemandaRepository();
            var demanda = demandaRepository.RecuperarDemandaById(id);

            return new Demanda
            {
                ArquitetoId = demanda.ArquitetoId,
                ApelidoLoja = demanda.ApelidoLoja
            };
        }

        public IEnumerable<Demanda> GetAllDemanda()
        {
            var demandaDomain = new DemandaRepository();
            return ListDtoToListDemanda(demandaDomain.GetAllDemanda());

        }
        public String Inserir(Demanda demanda)
        {
            //Validar se o apelido está preenchido
            if (demanda.ApelidoLoja != null && !demanda.ApelidoLoja.Equals("") && demanda.ApelidoLoja.Length >3)
            { 

                var demandaDB = new DemandaRepository();
                Guid idDemanda = Guid.NewGuid();
                demandaDB.Inserir(ConvertDemandaToDemandaDTO(demanda, idDemanda));
                return "Demanda "+ demanda.ApelidoLoja +" foi inserida." ;

            }
            else
            {
                var retError = new { Error = "Apelido Loja vazio ou menor que 3 caracteres." };
                return retError.Error;
            }
            
        }

        public void UpdateDemanda(Demanda demanda, Guid Id)
        {

            if (string.IsNullOrEmpty(demanda.ApelidoLoja))
            {
                throw new ArgumentException("Preencha o apelido da loja.");

            }

            if (string.IsNullOrEmpty(demanda.ArquitetoId.ToString()))
            {
                throw new ArgumentException("Preencha o ID do Arquiteto.");

            }

            var demandaDto = new DemandaDto();
            demandaDto.Id =Id;
            demandaDto.ArquitetoId = demanda.ArquitetoId;
            demandaDto.ApelidoLoja = demanda.ApelidoLoja;
            
            var demandaRepository = new DemandaRepository();
            demandaRepository.UpdateDemanda(demandaDto);                     
        }

        public Demanda DtotoDemanda(DemandaDto demandaDto) {

            var demanda = new Demanda();

            
            demanda.ApelidoLoja = demandaDto.ApelidoLoja;
            demanda.ArquitetoId = demandaDto.ArquitetoId;

            return demanda;
        }

        public IEnumerable<Demanda> ListDtoToListDemanda(IEnumerable<DemandaDto> demandasDto) {

            var demanda = new Demanda();

            IEnumerable<Demanda> demandasBase = Enumerable.Empty<Demanda>();
            var listEdit = demandasBase.ToList();

            foreach (DemandaDto demandaDto in demandasDto) {

                listEdit.Add(DtotoDemanda(demandaDto));      

            }

            return (IEnumerable<Demanda>) listEdit;   

        }

        public DemandaDto ConvertDemandaToDemandaDTO(Demanda demanda, Guid id)
        {
            var demandadto = new DemandaDto();
            demandadto.ApelidoLoja = demanda.ApelidoLoja;
            demandadto.ArquitetoId = demanda.ArquitetoId;
            demandadto.Id = id;

            return demandadto;
        }

        public void DeleteDemanda(Guid id)
        {
            var demandarep = new DemandaRepository();
            demandarep.DeleteDemanda(id);
        }
    }
}
