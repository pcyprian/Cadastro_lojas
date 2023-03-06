namespace cadastro_lojas_fullstack.Models
{
    public class Projeto
    {
        public string Bandeira { get; set; }
        public string ApelidoProjeto { get; set; }
        public string? NomeProjeto { get; set; }
        public string? CodigoLoja { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string? Categoria { get; set; }
        public string PerfilArquitetonico { get; set; }
        public  DateTime? DataInauguracao { get; set; }
        public bool Ativo { get; set; }
        public Guid DemandaId { get; set; }

    }
}
