using HelpMap.CrossCutting.Identity.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpMap.CrossCutting.Identity.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new GrupoMapping());
            modelBuilder.ApplyConfiguration(new ReuniaoMapping());
            modelBuilder.ApplyConfiguration(new ReuniaoAbertaMapping());
            modelBuilder.ApplyConfiguration(new InformacaoMapping());
            modelBuilder.ApplyConfiguration(new EventoMapping());

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "AspNetUser");
                entity.Property(e => e.Id).HasColumnName("AspNetUserId");
                entity.HasOne(c => c.Grupo).WithMany().HasForeignKey(x => x.IdGrupo);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}