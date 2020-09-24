using HelpMap.Domain.Models.Categorias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMap.Infrastructure.Mappings
{
    public class InformacaoMapping: IEntityTypeConfiguration<Informacao>
    {
        public void Configure(EntityTypeBuilder<Informacao> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("Id");

            builder.Property(e => e.Id)
                   .IsRequired()
                   .HasColumnType("INT");

            builder.Property(e => e.Titulo)
                   .HasColumnType("VARCHAR(150)")
                   .IsRequired();

            builder.Property(e => e.Texto)
                   .HasColumnType("TEXT")
                   .IsRequired();

            builder.HasOne(c => c.Categoria);

            builder.ToTable("Informacoes");
        }
    }
}