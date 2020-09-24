using HelpMap.Domain.Models.Reunioes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMap.Infrastructure.Mappings
{
    public class ReuniaoAbertaMapping : IEntityTypeConfiguration<ReuniaoAberta>
    {
        public void Configure(EntityTypeBuilder<ReuniaoAberta> builder)
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

            builder.ToTable("ReunioesAbertas");

            builder.HasOne(e => e.Grupo)
                    .WithMany(e => e.ReunioesAbertas)
                    .HasForeignKey(e => e.IdGrupo)
                    .IsRequired();
        }
    }
}