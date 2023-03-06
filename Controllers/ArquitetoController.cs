using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using cadastro_lojas_fullstack.Models;
using cadastro_lojas_fullstack.infra;
using cadastro_lojas_fullstack.Domain;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using FluentValidation;
using System.Net;
using Azure;
using cadastro_lojas_fullstack.DTO;

namespace cadastro_lojas_fullstack.Controllers;

[ApiController]
[Route("[controller]")]
public class ArquitetoController : ControllerBase
{
    private readonly ArquitetoServices arquitetoServices;
    private readonly IValidator<Arquiteto> _validator;

    public ArquitetoController(IValidator<Arquiteto> validator)
    {

        arquitetoServices = new ArquitetoServices();
        _validator = validator;
    }

    [HttpGet("GetAll")]
    public IEnumerable<Arquiteto> GetAll()
    {
        var arquitetoServices = new ArquitetoServices();
        return arquitetoServices.GetAllArquiteto();


    }


    [HttpGet("GetById/{id}")]
    public ActionResult GetById(Guid id)
    {
        var arquitetoServices = new ArquitetoServices();

        var arquitetos = arquitetoServices.GetArquitetoById(id);

        if (arquitetos == null)
        {
            return NotFound($"Arquiteto não encontrado com o Id ={id} informado");
        }

        return Ok(new
        {
            arquitetos,
            msg = $"Arquiteto com o ID = `{id}` encontrado",
            status = HttpStatusCode.OK
        });

    }


    [HttpPost("Create")]

    public ActionResult InsertArquiteto(Arquiteto arquiteto)
    {
        var validacao = _validator.Validate(arquiteto);
        if (!validacao.IsValid)
        {

            return BadRequest(validacao.ToDictionary());
        }

        var arquitetoServices = new ArquitetoServices();
        arquitetoServices.InsertArquiteto(arquiteto);
       

        return Created("Arquiteto criado com sucesso", arquiteto);
        

    }


    [HttpPut("Update/{id}")]
    public ActionResult UpdateArquiteto(Arquiteto arquiteto, Guid id)
    {
        var arquitetoServices = new ArquitetoServices();

        var validacao = _validator.Validate(arquiteto);

        if (!validacao.IsValid)
        {
            return BadRequest(validacao.ToDictionary());
        }

        var arquitetoDb = arquitetoServices.UpdateArquiteto(arquiteto,id);

        if (arquitetoDb is null)
        {
            return NotFound($"Arquiteto não encontrado com o Id ={id} informado");
        }

        return Ok(new
        {
            arquiteto,
            msg = $"Arquiteto com o ID = `{id}` atualizado com sucesso",
            status = HttpStatusCode.OK
        });
       

    }


    [HttpDelete("Delete/{id}")]
    public ActionResult DeleteArquiteto(Guid id)
    {
        var arquitetoServices = new ArquitetoServices();


        var arquitetoDb = arquitetoServices.DeleteArquiteto(id);

        if (arquitetoDb is false)
        {
            return NotFound($"Arquiteto não encontrado com o Id ={id} informado");
        }

        return Ok(new
        {
            msg = $"Arquiteto com o ID = `{id}` removido com sucesso",
            status = HttpStatusCode.OK
        });

    }

}
