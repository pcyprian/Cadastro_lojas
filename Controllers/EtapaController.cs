using Azure;
using cadastro_lojas_fullstack.Domain;
using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace cadastro_lojas_fullstack.Controllers;

[ApiController]
[Route("[controller]")]
public class EtapaController : ControllerBase
{
    private readonly EtapaServices _etapaServices;

    private readonly IValidator<Etapa> _validator;
    public EtapaController(IValidator<Etapa> validator) 
    {
        _validator = validator;
    }


    [HttpGet("GetAll")]
    public IEnumerable<Etapa> GetAll()
    {
        var etapaServices = new EtapaServices();
        return etapaServices.GetAllEtapa();
        
    }

    [HttpGet("GetById/{id}")]
    public ActionResult GetById(Guid id)
    {
        var etapaServices = new EtapaServices();
        var etapa = etapaServices.GetEtapaById(id);

        if (etapa == null)
        {
            return NotFound($"Etapa não encontrada com o Id ={id} informado");
        }

        return Ok(new
        {
            etapa,
            msg = $"Etapa com o ID = `{id}` encontrada",
            status = HttpStatusCode.OK
        });

    }


    [HttpPost("Create")]
    public ActionResult CreateEtapa(Etapa etapa) 
    {
        var etapaServices = new EtapaServices();

        var validation = _validator.Validate(etapa);
        if (!validation.IsValid)
        {
            return BadRequest(validation.ToDictionary());
        }


        etapaServices.InsertEtapa(etapa);
        return Created("Etapa criada com sucesso", etapa);
    }


    [HttpPut("Update/{id}")]
    public ActionResult UpdateEtapa(Etapa etapa, Guid id)
    {
        var etapaServices = new EtapaServices();

        var validation = _validator.Validate(etapa);
        if (!validation.IsValid)
        {
            return BadRequest(validation.ToDictionary());
        }

        var etapaDb = etapaServices.UpdateEtapa(etapa, id);

        if (etapaDb is null)
        {
            return NotFound($"Etapa não encontrada com o Id ={id} informado");
        }

        return Ok(new
        {
            etapa,
            msg = $"Etapa com o ID = `{id}` atualizada com sucesso",
            status = HttpStatusCode.OK
        });


    }


    [HttpDelete("Delete/{id}")]
    public ActionResult DeleteEtapa(Guid id)
    {
        var etapaServices = new EtapaServices();
       

        var etapaDb = etapaServices.DeleteEtapa(id);

        if (etapaDb is false)
        {
            return NotFound($"Etapa não encontrada com o Id ={id} informado");
        }

        return Ok(new
        {
            msg = $"Etapa com o ID = `{id}` removida com sucesso",
            status = HttpStatusCode.OK
        });

    }

}
