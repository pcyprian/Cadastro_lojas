using cadastro_lojas_fullstack.DTO;
using Microsoft.EntityFrameworkCore;

namespace cadastro_lojas_fullstack.Infra
{
    internal class DemandaRepository
    {
        private readonly CadastroLojasContext _context; 
        public DemandaRepository()
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsettings.Localhost.json").Build()
            .GetSection("StringDeConexao:Padrao").Value;
            var optionsBuilder = new DbContextOptionsBuilder<CadastroLojasContext>();
            optionsBuilder.UseSqlServer(connString);

            _context = new CadastroLojasContext(optionsBuilder.Options);
        }
        public bool Inserir(DemandaDto demanda)
        {
            try
            {
                _context.Demandas.Add(demanda);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public IEnumerable<DemandaDto> GetAllDemanda()
        {
            try
            {
                var demandas = _context.Demandas?.ToList();
                return demandas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public DemandaDto RecuperarDemandaById(Guid id)
        {
            try
            {
                var demandas = _context.Demandas?.ToList();
                DemandaDto? demandaDto = demandas?.Where(_ => _.Id == id).FirstOrDefault();


                return demandaDto;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }
        public bool UpdateDemanda(DemandaDto demandaDto)
        {
            try
            {
                _context.Demandas.Update(demandaDto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }



        public bool DeleteDemanda(Guid id)
        {
            try
            {
                var demandas = _context.Demandas?.Remove( new DemandaDto {Id = id });
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /*    public DemandaDto RecuperarDemandaById(Guid id)
            {
                var enderecoConexao = GetConnection();
                using var connection = new SqlConnection((string)enderecoConexao);
                {
                    try
                    {
                        connection.Open();
                        var queryString = $"SELECT * FROM demandas WHERE id = '{id}'";
                        var demandaId = connection.Query<DemandaDto>(queryString).FirstOrDefault();

                        return demandaId;
                    }
                    catch (Exception ex)
                    {
                        // tá caindo no catch pq não tenho coluna id no meu banco (eu acho)
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        */
        /*    public IEnumerable<DemandaDto> GetAllDemanda()
            {
                var enderecoConexao = GetConnection();
                using var connection = new SqlConnection((string)enderecoConexao);

                connection.Open();
                var demandas = connection.Query<DemandaDto>("SELECT * FROM demandas");
                connection.Close();
                return demandas;

            }*/
        /*     public void UpdateDemanda(DemandaDto demandaDto)
             {
                 var enderecoConexao = GetConnection();
                 using var connection = new SqlConnection((string)enderecoConexao);

                 connection.Open();
                 var etapas = connection.Execute("UPDATE demandas SET " +
                                               "apelidoLoja = @apelidoLoja, ArquitetoId = @ArquitetoId " +
                                               "WHERE id = @demandaId", demandaDto);
                 connection.Close();

             }
        */
        /*private object GetConnection()
        {
            var connection = "Data Source = LENOVO-PC\\SQLEXPRESS;Database=dbcadastrolojas;user id = sa; password=12345;";
            return connection;
        }*/
    }
}