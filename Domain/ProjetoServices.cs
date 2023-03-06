using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Infra;
using cadastro_lojas_fullstack.Models;

namespace cadastro_lojas_fullstack.Domain
{
    public class ProjetoServices
    {

        public Projeto GetProjetoById(Guid id)
        {
            var projetoRepository = new ProjetoRepository();
            var projeto = new ProjetoDto();
            projeto = projetoRepository.RecuperarProjetoById(id);

            return new Projeto
            {
                Bandeira = projeto.Bandeira,
                ApelidoProjeto = projeto.ApelidoLoja,
                NomeProjeto = projeto.NomeProjeto,
                CodigoLoja = projeto.CodigoLoja,
                Cep = projeto.Cep,
                Estado = projeto.Estado,
                Municipio = projeto.Municipio,
                Categoria = projeto.Categoria,
                PerfilArquitetonico = projeto.PerfilArquitetonico,
                DataInauguracao = projeto.DataInauguracao,
                Ativo = projeto.Ativo,
                DemandaId = (Guid)projeto.DemandaId
            };
        }
        public IEnumerable<Projeto> GetAllProjeto()
        {
            var projetos = new List<Projeto>();
            var projetoDomain = new ProjetoRepository();
            var projetosDto = projetoDomain.GetAllProjeto();
            foreach (var projeto in projetosDto)
            {
                projetos.Add
                (
                    new Projeto
                    {
                        Bandeira = projeto.Bandeira,
                        ApelidoProjeto = projeto.ApelidoLoja,
                        NomeProjeto = projeto.NomeProjeto,
                        CodigoLoja = projeto.CodigoLoja,
                        Cep = projeto.Cep,
                        Estado = projeto.Estado,
                        Municipio = projeto.Municipio,
                        Categoria = projeto.Categoria,
                        PerfilArquitetonico = projeto.PerfilArquitetonico,
                        DataInauguracao = projeto.DataInauguracao,
                        Ativo = projeto.Ativo,
                        DemandaId = (Guid)projeto.DemandaId
                    }
                );
            }
            return projetos;

        }

        //Não sei fazer o if do Booleano "Ativo"
        public string InsertProjeto(Projeto projeto)
        {
            if (string.IsNullOrEmpty(projeto.Bandeira))
            {
                throw new ArgumentException("O campo Bandeira é obrigatório.");
            }

            if (string.IsNullOrEmpty(projeto.ApelidoProjeto))
            {
                throw new ArgumentException("O campo apelido do projeto é obrigatório.");
            }

            if (string.IsNullOrEmpty(projeto.Estado))
            {
                throw new ArgumentException("O campo Estado é obrigatório.");
            }

            if (string.IsNullOrEmpty(projeto.Municipio))
            {
                throw new ArgumentException("O campo município é obrigatório.");
            }

            if (string.IsNullOrEmpty(projeto.PerfilArquitetonico))
            {
                throw new ArgumentException("O campo perfil arquitetônico é obrigatório.");
            }

            if (string.IsNullOrEmpty(projeto.Ativo.ToString()))
            {
                // melhorar
                throw new ArgumentException("Denomine se é Ativo ou não.");
            }

            if (string.IsNullOrEmpty(projeto.Cep))
            {
                throw new ArgumentException("O campo CEP é obrigatório.");
            }

            var projetoDto = new ProjetoDto();
            projetoDto.Bandeira = projeto.Bandeira;
            projetoDto.ApelidoLoja = projeto.ApelidoProjeto;
            projetoDto.NomeProjeto = projeto.NomeProjeto;
            projetoDto.CodigoLoja = projeto.CodigoLoja;
            projetoDto.Cep = projeto.Cep;
            projetoDto.Estado = projeto.Estado;
            projetoDto.Municipio = projeto.Municipio;
            projetoDto.Categoria = projeto.Categoria;
            projetoDto.PerfilArquitetonico = projeto.PerfilArquitetonico;
            projetoDto.DataInauguracao = projeto.DataInauguracao;
            projetoDto.Ativo = projeto.Ativo;
            projetoDto.DemandaId = projeto.DemandaId;

            var projetoRepository = new ProjetoRepository();
            if(projetoRepository.InsertProjeto(projetoDto))
            {
                return "Projeto inserido com sucesso!!!";
            }

            return "Projeto não inserido...";
        }

        public void UpdateProjeto(Projeto projeto, Guid id)
        {
            var projetoDomain = new ProjetoRepository();

       
            projetoDomain.UpdateProjeto(ConvertProjetoToProjetoDTO(projeto, id));
        }

        public Guid GetIdProjetoPorIdDemanda(Guid idDemanda)
        {
            var projetoDomain = new ProjetoRepository();
            return projetoDomain.GetIdProjetoPorIdDemanda(idDemanda);
        }

        public void DeleteProjeto(Guid IdProjeto)
        {
            var projetoDomain = new ProjetoRepository();
            projetoDomain.DeleteProjeto(IdProjeto);
        }


        public ProjetoDto ConvertProjetoToProjetoDTO(Projeto projeto, Guid id)
        {
            var projetoDto = new ProjetoDto();


            projetoDto.Bandeira = projeto.Bandeira;
            projetoDto.ApelidoLoja = projeto.ApelidoProjeto;
            projetoDto.NomeProjeto = projeto.NomeProjeto;
            projetoDto.CodigoLoja = projeto.CodigoLoja;
            projetoDto.Cep = projeto.Cep;
            projetoDto.Estado = projeto.Estado;
            projetoDto.Municipio = projeto.Municipio;
            projetoDto.Categoria = projeto.Categoria;
            projetoDto.PerfilArquitetonico = projeto.PerfilArquitetonico;
            projetoDto.DataInauguracao = projeto.DataInauguracao;
            projetoDto.Ativo = projeto.Ativo;
            projetoDto.DemandaId = projeto.DemandaId;



            return projetoDto;
        }
    }

}
