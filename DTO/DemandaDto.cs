using cadastro_lojas_fullstack.Models;
using System.ComponentModel.DataAnnotations;

namespace cadastro_lojas_fullstack.DTO
{
    public class DemandaDto
    {
        public Guid? Id { get; set; }
        public string? ApelidoLoja { get; set; }
        public Guid? ArquitetoId { get; set; }
        public ArquitetoDto? Arquiteto { get; set; }


    }
}
