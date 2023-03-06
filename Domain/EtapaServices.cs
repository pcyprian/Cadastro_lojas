using cadastro_lojas_fullstack.Infra;
using cadastro_lojas_fullstack.Models;
using cadastro_lojas_fullstack.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cadastro_lojas_fullstack.Domain;

public class EtapaServices
{
    //private readonly EtapaRepository _etapaRepository;
    public EtapaServices()
    {
    }

    public IEnumerable<Etapa> GetAllEtapa()
    {
        var etapas = new List<Etapa>();
        var etapaServices = new EtapaRepository();
        var etapasDto = etapaServices.GetAllEtapa();

        foreach (var etapa in etapasDto)
        {
            etapas.Add
                (
                    new Etapa
                    {
                        idProjeto = etapa.idProjeto,
                        etapaProjeto = etapa.etapaProjeto,
                        tipoObra = etapa.tipoObra,
                        parceiroSubLocacao = etapa.parceiroSubLocacao,
                        tipoEstacionamento = etapa.tipoEstacionamento,
                        aplicacao = etapa.aplicacao,
                        numeroVagas = etapa.numeroVagas,
                        totem = etapa.totem,
                        toldo = etapa.toldo,
                        elementoHorizontal = etapa.elementoHorizontal,
                        led = etapa.led,
                        dimmer = etapa.dimmer,
                        arCondicionado = etapa.arCondicionado
                    }
                );
        }
    return etapas;

}

    
    public EtapaDto GetEtapaById(Guid id)
    {
        var etapaRepository = new EtapaRepository();
        var etapa = etapaRepository.GetById(id);

        return etapa;

    }

    public void InsertEtapa(Etapa etapa)
    {

        if (!etapa.idProjeto.HasValue || etapa.idProjeto == Guid.Empty)
        {
            throw new ArgumentException("O campo Id é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.etapaProjeto))
        {
            throw new ArgumentException("O campo etapa é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.tipoObra))
        {
            throw new ArgumentException("O campo tipo de obra é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.parceiroSubLocacao))
        {
            throw new ArgumentException("O campo parceiro subLocacao é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.tipoEstacionamento))
        {
            throw new ArgumentException("O campo tipoEstacionamento é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.aplicacao))
        {
            throw new ArgumentException("O campo aplicacao é obrigatório para o cadastro!!!");
        }

        if (!etapa.numeroVagas.HasValue)
        {
            throw new ArgumentException("O campo numero de vagas é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.totem))
        {
            throw new ArgumentException("O campo totem é obrigatório para o cadastro!!!");
        }

        if (!etapa.toldo.HasValue)
        {
            throw new ArgumentException("O campo toldo é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.elementoHorizontal))
        {
            throw new ArgumentException("O campo elemento horizontal é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.led))
        {
            throw new ArgumentException("O campo led é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.dimmer))
        {
            throw new ArgumentException("O campo dimmer é obrigatório para o cadastro!!!");
        }

        if (string.IsNullOrEmpty(etapa.arCondicionado))
        {
            throw new ArgumentException("O campo ar condicionado é obrigatório para o cadastro!!!");
        }

        var etapaDto = new EtapaDto();

        etapaDto.idProjeto = etapa.idProjeto;
        etapaDto.etapaProjeto = etapa.etapaProjeto;
        etapaDto.tipoObra = etapa.tipoObra;
        etapaDto.parceiroSubLocacao = etapa.parceiroSubLocacao;
        etapaDto.tipoEstacionamento = etapa.tipoEstacionamento;
        etapaDto.aplicacao = etapa.aplicacao;
        etapaDto.numeroVagas = etapa.numeroVagas;
        etapaDto.totem = etapa.totem;
        etapaDto.toldo = etapa.toldo;
        etapaDto.elementoHorizontal = etapa.elementoHorizontal;
        etapaDto.led = etapa.led;
        etapaDto.dimmer = etapa.dimmer;
        etapaDto.arCondicionado = etapa.arCondicionado;

        var etapaServices = new EtapaRepository();
        etapaServices.InsertEtapa(etapaDto);


    }

    public Etapa UpdateEtapa(Etapa etapa, Guid id)
    {

        var etapaRepository = new EtapaRepository();

        var etapaDto = new EtapaDto();

        etapaDto.Id = id;
        etapaDto.idProjeto = etapa.idProjeto;
        etapaDto.etapaProjeto = etapa.etapaProjeto;
        etapaDto.tipoObra = etapa.tipoObra;
        etapaDto.parceiroSubLocacao = etapa.parceiroSubLocacao;
        etapaDto.tipoEstacionamento = etapa.tipoEstacionamento;
        etapaDto.aplicacao = etapa.aplicacao;
        etapaDto.numeroVagas = etapa.numeroVagas;
        etapaDto.totem = etapa.totem;
        etapaDto.toldo = etapa.toldo;
        etapaDto.elementoHorizontal = etapa.elementoHorizontal;
        etapaDto.led = etapa.led;
        etapaDto.dimmer = etapa.dimmer;
        etapaDto.arCondicionado = etapa.arCondicionado;

        var etapaDb = etapaRepository.UpdateEtapa(etapaDto);


        if (etapaDb is not null)
        {
            return etapa;
        }

        return null;

    }

    public bool DeleteEtapa(Guid id)
    {
        var etapaRepository = new EtapaRepository();

        var etapaDb = etapaRepository.GetById(id);

        if (etapaDb is not null)
        {
            etapaRepository.DeleteEtapa(id);
            return true;
        }

        return false;
        
    }

}
