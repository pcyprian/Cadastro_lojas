using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace cadastro_lojas_fullstack.Infra;

public class ProjetoRepository
{
    private readonly CadastroLojasContext _context;
    public ProjetoRepository()
    {
        var connString = new ConfigurationBuilder().AddJsonFile("appsettings.Localhost.json").Build()
             .GetSection("StringDeConexao:Padrao").Value;
        var optionsBuilder = new DbContextOptionsBuilder<CadastroLojasContext>();
        optionsBuilder.UseSqlServer(connString);

        _context = new CadastroLojasContext(optionsBuilder.Options);
    }

    public bool InsertProjeto(ProjetoDto projetoDto)
    {
        {
            try
            {
                _context.Projetos.Add(projetoDto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
    public ProjetoDto RecuperarProjetoById(Guid id)
    {
        try
        {
            var projetos = _context.Projetos?.ToList();
            ProjetoDto? projetoDto = projetos?.Where(_ => _.Id == id).FirstOrDefault();


            return projetoDto;
        }

        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

    public IEnumerable<ProjetoDto> GetAllProjeto()
    {
        try
        {
            var projetos = _context.Projetos?.ToList();
            return projetos;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }

    }

    public bool UpdateProjeto(ProjetoDto projeto)
    {
        try
        {
            _context.Projetos.Update(projeto);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }

    }

    public bool DeleteProjeto(Guid id)
    {
        try
        {
            var projetos = _context.Projetos?.Remove(new ProjetoDto { Id = id });
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

        public Guid GetIdProjetoPorIdDemanda(Guid idDemanda)
        {
            try
            {
                var projeto = _context.Projetos.ToList();
                ProjetoDto? projetoDto = projeto?.Where(_ => _.DemandaId == idDemanda).FirstOrDefault();
                return projetoDto.Id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
 

    }

}