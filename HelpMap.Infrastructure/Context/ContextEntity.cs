using HelpMap.Domain.Models.Categorias;
using HelpMap.Domain.Models.Categories;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Domain.Models.Reunioes;
using HelpMap.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HelpMap.Infrastructure.Context
{
    public class ContextEntity : DbContext
    {
        public ContextEntity(DbContextOptions<ContextEntity> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Reuniao> Reunioes { get; set; }
        public DbSet<ReuniaoAberta> ReunioesAbertas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Informacao> Informacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new GrupoMapping());
            modelBuilder.ApplyConfiguration(new ReuniaoMapping());
            modelBuilder.ApplyConfiguration(new ReuniaoAbertaMapping());
            modelBuilder.ApplyConfiguration(new InformacaoMapping());
            modelBuilder.ApplyConfiguration(new EventoMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), o => o.UseNetTopologySuite());
        }
    }
}
