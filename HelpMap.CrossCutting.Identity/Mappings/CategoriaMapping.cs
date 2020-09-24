using HelpMap.Domain.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMap.CrossCutting.Identity.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
                   .HasColumnName("Id");

            builder.Property(e => e.Id)
                   .IsRequired()
                   .HasColumnType("INT");

            builder.Property(e => e.Nome)
                   .HasColumnType("VARCHAR(150)")
                   .IsRequired();

            builder.HasMany(e => e.Grupos)
                   .WithOne(e => e.Categoria);

            builder.HasMany(e => e.Informacoes)
                   .WithOne(e => e.Categoria)
                   .IsRequired();

            builder.ToTable("Categorias");
        }
    }
}