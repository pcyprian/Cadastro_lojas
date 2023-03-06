
using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Infra;
using cadastro_lojas_fullstack.Models;
using Microsoft.EntityFrameworkCore;



namespace cadastro_lojas_fullstack.infra;

public class ArquitetoRepository
{
    private readonly CadastroLojasContext _context;
    public ArquitetoRepository()
    {
        var connString = new ConfigurationBuilder().AddJsonFile("appsettings.Localhost.json").Build()
        .GetSection("StringDeConexao:Padrao").Value;

        var optionsBuilder = new DbContextOptionsBuilder<CadastroLojasContext>();
        optionsBuilder.UseSqlServer(connString);

        _context = new CadastroLojasContext(optionsBuilder.Options);
    }

    public IEnumerable<ArquitetoDto> GetAllArquiteto()
    {
        try
        {
            var arquitetos = _context.Arquitetos?.ToList();
            return arquitetos;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }

    }

    public ArquitetoDto? GetById(Guid id)
    {
        try
        {
            var arquitetos = _context.Arquitetos.SingleOrDefault(a => a.Id == id);

            return arquitetos;
        }

        catch (Exception e)
        {

            throw new Exception(e.Message);
        }

    }
    public bool InsertArquiteto(ArquitetoDto arquitetoDto)
    {
        try
        {
            _context.Arquitetos.Add(arquitetoDto);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }

    }


    public ArquitetoDto UpdateArquiteto(ArquitetoDto arquitetoDto)
    {
        try
        {
            var arquitetos = _context.Arquitetos.SingleOrDefault(a => a.Id == arquitetoDto.Id);

            if (arquitetos is not null)
            {
                _context.Entry(arquitetos).State = EntityState.Detached;

                _context.Arquitetos.Update(arquitetoDto);
                _context.SaveChanges();

                return arquitetos;
            }
            return arquitetos;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

    public bool DeleteArquiteto(Guid id)
    {
        try
        {   
            var arquiteto = _context.Arquitetos.First(a => a.Id == id );

            if (arquiteto is null)
            {
                throw new Exception($"Arquiteto com o Id `{id}` não encontrado");
            }

            _context.Arquitetos.Remove(arquiteto);
            _context.SaveChanges();

            return true;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }

    }

}