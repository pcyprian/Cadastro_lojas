using cadastro_lojas_fullstack.DTO;
using cadastro_lojas_fullstack.Models;
using Microsoft.EntityFrameworkCore;


namespace cadastro_lojas_fullstack.Infra
{
    public class CadastroLojasContext : DbContext
    {

        public CadastroLojasContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<DemandaDto> Demandas { get; set; }
        public DbSet<ArquitetoDto> Arquitetos { get; set; }
        public DbSet<MedidaDto> Medidas { get; set; }
        public DbSet<ProjetoDto> Projetos { get; set; }
        public DbSet<EtapaDto> Etapas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArquitetoDto>(_ =>
            {
                _.ToTable("Arquitetos");
                _.HasKey(x => x.Id);
                _.Property(x => x.Id).ValueGeneratedOnAdd();

            });
            modelBuilder.Entity<DemandaDto>(_ =>
            {
                _.ToTable("Demandas");
                _.HasKey(y => y.Id);
                _.HasOne(x => x.Arquiteto);
                _.Property(y => y.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProjetoDto>(_ =>
            {
                _.ToTable("Projetos");
                _.HasKey(x => x.Id);
                _.HasOne(x => x.Demanda);
                _.Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<MedidaDto>(_ =>
            {
                _.ToTable("Medidas");
                _.HasKey(x => x.Id);
                _.HasOne(x => x.Projeto);
                _.Property(x => x.Id).ValueGeneratedOnAdd();

            });
            modelBuilder.Entity<EtapaDto>(_ =>
            {
                _.ToTable("Etapas");
                _.HasKey(x => x.Id);
                _.HasOne(x => x.Projeto);
                _.Property(x => x.Id).ValueGeneratedOnAdd();

            });

            });

        }
    }
}

