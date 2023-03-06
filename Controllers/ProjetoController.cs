using cadastro_lojas_fullstack.Domain;
using cadastro_lojas_fullstack.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_lojas_fullstack.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjetoController : ControllerBase
{
    private readonly ProjetoServices projetoServices;
    private readonly IValidator<Projeto> _validator;

    public ProjetoController(IValidator<Projeto> validato)
    {
        projetoServices = new ProjetoServices();
        _validator = validato;
    }

    [HttpGet("get-projeto/{id}")]
    public ActionResult GetById(Guid id)
    {
        var lojaDomain = new ProjetoServices();
        var lojas = lojaDomain.GetProjetoById(id);
        if (lojas == null)
        {
            return NotFound($"Demanda não encontrado com o Id ={id} informado");
        }
        return Ok(lojas);
    }


    [HttpGet("get-all-projetos")]
    public IEnumerable<Projeto> GetAll()
    {
        var lojaDomain = new ProjetoServices();
        return lojaDomain.GetAllProjeto();
    }

    [HttpPost("insert-projeto")]
    public ActionResult InsertLoja(Projeto projeto)
    {
        var validacao = _validator.Validate(projeto);
        if (!validacao.IsValid)
        {
            return BadRequest(validacao.ToDictionary());
        }
        var lojaDomain = new ProjetoServices();
        lojaDomain.InsertProjeto(projeto);
        string resposta = "O Projeto " + projeto.ApelidoProjeto.ToString() + " foi adicionado";
        return Created(resposta, projeto);
    }


    [HttpPut("IdLoja/{id}")]
    public ActionResult UpdateLoja(Projeto loja, Guid id)
    {
        var validacao = _validator.Validate(loja);
        if (!validacao.IsValid)
        {
            return BadRequest(validacao.ToDictionary());
        }
        var lojaDomain = new ProjetoServices();
        lojaDomain.UpdateProjeto(loja, id);
        string resposta = "O Projeto " + loja.ApelidoProjeto.ToString() + " foi atualizado";
        return Ok(resposta);
    

    }


    [HttpDelete("IdLoja {id}")]
    public ActionResult DeleteLoja(Guid id)
    {
        var lojaDomain = new ProjetoServices();
        lojaDomain.DeleteProjeto(id);
        return Ok("Loja removida com sucesso.");

    }
}
