using Azure;
using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace cadastro_lojas_fullstack.Infra
{
    public class MedidaRepository
    {
        private CadastroLojasContext _context;
        public MedidaRepository()
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsettings.Localhost.json").Build()
            .GetSection("StringDeConexao:Padrao").Value;
            var optionsBuilder = new DbContextOptionsBuilder<CadastroLojasContext>();
            optionsBuilder.UseSqlServer(connString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            _context = new CadastroLojasContext(optionsBuilder.Options);
        }

        public IEnumerable<MedidaDto> GetAllMedida()
        {
            try
            {
                var medidas = _context.Medidas?.ToList();
                return medidas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool InsertMedida(MedidaDto medida)
        {
            try
            {
                _context.Medidas.Add(medida);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        

        public bool UpdateMedida(MedidaDto medidaDto)
        {
            
            
            try
            {
                _context.Medidas.Update(medidaDto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool DeleteMedida(Guid id)
        {
            try
            {
                MedidaDto medida = _context.Medidas?.First(e => e.Id == id);
                
                if(medida is null)
                {
                    throw new Exception($"Medida com o Id `{id}` não encontrada");
                }

                _context.Medidas.Remove(medida);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public MedidaDto RecuperarMedidaById(Guid id)
        {
            try
            {
                var medidas = _context.Medidas?.ToList();
                MedidaDto? medidaDto = medidas?.Where(_ => _.Id == id).FirstOrDefault();


                return medidaDto;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

            public Guid GetIdMedidaPorIdProjeto(Guid idProjeto)
        {
            try
            {
                var medidas = _context.Medidas.ToList();    
                MedidaDto? medidaDto = medidas?.Where(_ => _.ProjetoId == idProjeto).FirstOrDefault();
                return (Guid) medidaDto.Id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}

