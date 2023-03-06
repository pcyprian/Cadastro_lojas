using Microsoft.AspNetCore.Mvc;
using cadastro_lojas_fullstack.Models;
using cadastro_lojas_fullstack.Domain;
using FluentValidation;

namespace cadastro_lojas_fullstack.Controllers;

[ApiController]
[Route("[controller]")]
public class DemandaController : ControllerBase
{
    private readonly DemandaServices _demandaServices;

    private readonly IValidator<Demanda> _validator;
    public DemandaController(IValidator<Demanda> validator)
    {
        _validator = validator;
    }



    [HttpGet("buscar-demanda")]
    public IEnumerable<Demanda> GetAll()
    {
        var demandaDomain = new DemandaServices();
        return demandaDomain.GetAllDemanda();
    }

    [HttpPost("inserir-demanda")]
    public ActionResult Inserir(Demanda demanda)
    {
        var demandaServices = new DemandaServices();

        var validation = _validator.Validate(demanda);
        if (!validation.IsValid)
        {
            return BadRequest(validation.ToDictionary());
        }

        demandaServices.Inserir(demanda);
        return Created("Demanda criada com sucesso", demanda);

    }

    [HttpPut("Id")]
    public ActionResult UpdateDemanda(Demanda demanda, Guid Id)
    {
        var demandaDomain = new DemandaServices();
        demandaDomain.UpdateDemanda(demanda, Id);
        return Ok(demanda);

    }


    [HttpDelete("Demanda/Delete/{Id}")]
    public ActionResult DeleteDemanda(Guid Id)
    {
        var demandaDomain = new DemandaServices();
        demandaDomain.DeleteDemanda(Id);
        return Ok("Removido com sucesso");

    }

    [HttpGet("get-demanda/{Id}")]
    public ActionResult GetById(Guid Id)
    {
        var demandaDomain = new DemandaServices();
        var demandas = demandaDomain.GetDemandaById(Id);
        if (demandas == null)
        {
            return NotFound($"Demanda não encontrado com o Id ={Id} informado");
        }
        return Ok(demandas);
    }
}





