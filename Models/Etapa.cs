using System;


namespace cadastro_lojas_fullstack.Models;

public class Etapa
{
    public Guid? idProjeto { get; set; }
    public string? etapaProjeto { get; set; }
    public string? tipoObra { get; set; }
    public string? parceiroSubLocacao { get; set; }
    public string? tipoEstacionamento { get; set; }
    public string? aplicacao { get; set; }
    public int? numeroVagas { get; set; }
    public string? totem { get; set; }
    public int? toldo { get; set; }
    public string? elementoHorizontal { get; set; }
    public string? led { get; set; }
    public string? dimmer { get; set; }
    public string? arCondicionado { get; set; }
}
