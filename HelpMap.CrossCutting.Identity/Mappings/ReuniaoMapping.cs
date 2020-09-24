using HelpMap.Domain.Models.Reunioes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMap.CrossCutting.Identity.Mappings
{
    public class ReuniaoMapping : IEntityTypeConfiguration<Reuniao>
    {
        public void Configure(EntityTypeBuilder<Reuniao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
                   .HasColumnName("Id");

            builder.Property(e => e.Dia)
                   .HasColumnType("VARCHAR(20)")
                   .IsRequired();

            builder.Property(e => e.Inicio)
                   .HasColumnType("DATETIME")
                   .IsRequired();

            builder.Property(e => e.Fim)
                   .HasColumnType("DATETIME")
                   .IsRequired();

            builder.HasOne(e => e.Grupo)
                   .WithMany(e => e.Reunioes)
                   .HasForeignKey(e => e.IdGrupo)
                   .IsRequired();

            builder.ToTable("Reunioes");
        }
    }
}