using cadastro_lojas_fullstack.Infra;
using cadastro_lojas_fullstack.infra;
using cadastro_lojas_fullstack.Models;
using Microsoft.AspNetCore.Mvc;
using cadastro_lojas_fullstack.DTO;
using Azure;

namespace cadastro_lojas_fullstack.Domain
{
    public class ArquitetoServices
    {
        public IEnumerable<Arquiteto> GetAllArquiteto()
        {
            var arquitetos = new List<Arquiteto>();
            var arquitetoRepository = new ArquitetoRepository();
            var arquitetosDto = arquitetoRepository.GetAllArquiteto();

            foreach (var arquiteto in arquitetosDto)
            {
                arquitetos.Add
                (
                    new Arquiteto
                    {
                        ativo = arquiteto.ativo,
                        cnpjArquiteto = arquiteto.cnpjArquiteto,
                        dataContratacao = arquiteto.dataContratacao,
                        dataDesligamento = arquiteto.dataDesligamento,
                        dataNascimento = arquiteto.dataNascimento,
                        emailArquiteto = arquiteto.emailArquiteto,
                        nomeArquiteto = arquiteto.nomeArquiteto
                    }
                );
            }
            return arquitetos;
        }

        public ArquitetoDto GetArquitetoById(Guid id)
        {
            var arquitetoRepository = new ArquitetoRepository();
            var arquiteto = arquitetoRepository.GetById(id);

            return arquiteto;

        }

        public void InsertArquiteto(Arquiteto arquiteto)
        {
            if (string.IsNullOrEmpty(arquiteto.nomeArquiteto))
            {
                throw new ArgumentException("O nome é obrigatório para o cadastro.");
            }

            if (string.IsNullOrEmpty(arquiteto.emailArquiteto))
            {
                throw new ArgumentException("O e-mail é obrigatório para o cadastro.");
            }

            if (string.IsNullOrEmpty(arquiteto.cnpjArquiteto))
            {
                throw new ArgumentException("O CNPJ é obrigatório para o cadastro.");
            }

            var arquitetoDto = new ArquitetoDto();

            arquitetoDto.nomeArquiteto = arquiteto.nomeArquiteto;
            arquitetoDto.emailArquiteto = arquiteto.emailArquiteto;
            arquitetoDto.cnpjArquiteto = arquiteto.cnpjArquiteto;
            arquitetoDto.dataNascimento = arquiteto.dataNascimento;
            arquitetoDto.dataContratacao = arquiteto.dataContratacao;
            arquitetoDto.dataDesligamento = arquiteto.dataDesligamento;
            arquitetoDto.ativo = arquiteto.ativo;

            var arquitetoServices = new ArquitetoRepository();
            arquitetoServices.InsertArquiteto(arquitetoDto);

        }


        public Arquiteto UpdateArquiteto(Arquiteto arquiteto, Guid id)
        {

            var arquitetoRepository = new ArquitetoRepository();

            var arquitetoDto = new ArquitetoDto();

            arquitetoDto.Id = id;
            arquitetoDto.nomeArquiteto = arquiteto.nomeArquiteto;
            arquitetoDto.cnpjArquiteto = arquiteto.cnpjArquiteto;
            arquitetoDto.emailArquiteto = arquiteto.emailArquiteto;
            arquitetoDto.dataNascimento = arquiteto.dataNascimento;
            arquitetoDto.dataContratacao = arquiteto.dataContratacao;
            arquitetoDto.dataDesligamento = arquiteto.dataDesligamento;
            arquitetoDto.ativo = arquiteto.ativo;

            var arquitetoDb = arquitetoRepository.UpdateArquiteto(arquitetoDto);

            if (arquitetoDb is not null)
            {
                
                return arquiteto;
            }

            return null;


    }

        public bool DeleteArquiteto(Guid id)
        {
            var arquitetoRepository = new ArquitetoRepository();
            var arquitetoDb = arquitetoRepository.GetById(id);

            if (arquitetoDb is not null)
            {
                arquitetoRepository.DeleteArquiteto(id);
                return true;
            }

            return false;
        }

    }
}
