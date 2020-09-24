using HelpMap.Domain.Models.Grupos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMap.Infrastructure.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("Id");

            builder.Property(e => e.Logradouro)
                   .HasColumnType("VARCHAR(150)")
                   .IsRequired();

            builder.Property(e => e.PontoReferencia)
                   .HasColumnType("VARCHAR(150)")
                   .IsRequired();

            builder.ToTable("Enderecos");
        }
    }
}