using cadastro_lojas_fullstack.DTO;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 

namespace cadastro_lojas_fullstack.Models;

public class ArquitetoDto
{

    public Guid? Id { get; set; }
    public string? nomeArquiteto { get; set; }
    public string? cnpjArquiteto { get; set; }
    public string? emailArquiteto { get; set; }
    public DateTime? dataNascimento { get; set; }
    public DateTime? dataContratacao { get; set; }
    public DateTime? dataDesligamento { get; set; }
    public byte ativo { get; set; }

}
