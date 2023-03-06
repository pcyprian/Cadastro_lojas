using System;


namespace cadastro_lojas_fullstack.DTO;

public class EtapaDto
{
    public Guid? Id { get; set; }
    public string? etapaProjeto { get; set; }
    public string? tipoObra { get; set; }
    public string? parceiroSubLocacao { get; set; }
    public string? tipoEstacionamento { get; set; }
    public string? aplicacao { get; set; }
    public Nullable<int> numeroVagas { get; set; }
    public string? totem { get; set; }
    public Nullable <int> toldo { get; set; }
    public string? elementoHorizontal { get; set; }
    public string? led { get; set; }
    public string? dimmer { get; set; }
    public string? arCondicionado { get; set; }
    public ProjetoDto? Projeto { get; set; }
    public Guid? idProjeto { get; set; }
}

