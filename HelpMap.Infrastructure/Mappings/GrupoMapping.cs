using HelpMap.Domain.Models.Grupos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMap.Infrastructure.Mappings
{
    public class GrupoMapping : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("Id");

            builder.Property(e => e.Nome)
                   .HasColumnType("VARCHAR(100)")
                   .IsRequired();

           builder.Property(e => e.Recado)
                   .HasColumnType("VARCHAR(150)");

            builder.HasMany(c => c.Eventos)
               .WithOne(e => e.Grupo);

            builder.HasMany(c => c.Reunioes)
              .WithOne(e => e.Grupo);

            builder.HasMany(c => c.ReunioesAbertas)
              .WithOne(e => e.Grupo);

            builder.HasOne(e => e.Categoria)
                    .WithMany(e => e.Grupos)
                    .HasForeignKey(e => e.IdCategoria)
                    .IsRequired();

            builder.HasOne(c => c.Endereco);

            builder.ToTable("Grupos");
        }
    }
}