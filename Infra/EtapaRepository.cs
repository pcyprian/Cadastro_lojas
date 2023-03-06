
using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Models;
using Microsoft.EntityFrameworkCore;



namespace cadastro_lojas_fullstack.Infra;

public class EtapaRepository
{
    private CadastroLojasContext _context;

    public EtapaRepository ()
    {
        var connString = new ConfigurationBuilder().AddJsonFile("appsettings.Localhost.json").Build()
           .GetSection("StringDeConexao:Padrao").Value;


        var optionsBuilder = new DbContextOptionsBuilder<CadastroLojasContext>();
        optionsBuilder.UseSqlServer(connString);

        _context = new CadastroLojasContext(optionsBuilder.Options);

    }

    public IEnumerable<EtapaDto> GetAllEtapa()
    {
        try
        {
            var etapas = _context.Etapas?.ToList();
            return etapas;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }


    public EtapaDto? GetById(Guid id)
    {
        try
        {
            var etapas = _context.Etapas.SingleOrDefault(e => e.Id == id);
           //_context.Entry(etapas).State = EntityState.Detached;
            return etapas;
        }

        catch (Exception e)
        {

            throw new Exception(e.Message);
        }


    }

    public bool InsertEtapa(EtapaDto etapaDto)
    {
        try
        {
            _context.Etapas.Add(etapaDto);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }

    }

    public EtapaDto UpdateEtapa(EtapaDto etapaDto)
    {
        try
        {
            var etapas = _context.Etapas.SingleOrDefault(e => e.Id == etapaDto.Id);
            

            if (etapas is not null)
            {
                _context.Entry(etapas).State = EntityState.Detached;

                _context.Etapas.Update(etapaDto);
                _context.SaveChanges();
                return etapas;
            }
            return etapas;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public bool DeleteEtapa(Guid id) { 
        try
        {
            var etapa = _context.Etapas.First(e => e.Id == id );

            if (etapa is null)
            {
                throw new Exception($"Etapa com o Id `{id}` não encontrada");
            }

            _context.Etapas.Remove(etapa);
            _context.SaveChanges();

            return true;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }


}