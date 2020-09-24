using HelpMap.Domain.Models.Grupos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMap.Infrastructure.Mappings
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
                   .HasColumnName("Id");

            builder.Property(e => e.Titulo)
                   .HasColumnType("VARCHAR(100)")
                   .IsRequired();

            builder.Property(e => e.Descricao)
                   .HasColumnType("TEXT")
                   .IsRequired();

            builder.Property(e => e.Valor)
                .HasColumnType("DECIMAL")
                .IsRequired();

            builder.Property(e => e.Gratuito)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(e => e.Aberto)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(e => e.Dia)
               .HasColumnType("DATETIME")
               .IsRequired();

            builder.Property(e => e.HorarioInicio)
               .HasColumnType("DATETIME")
               .IsRequired();

            builder.Property(e => e.HorarioFim)
               .HasColumnType("DATETIME")
               .IsRequired();

            builder.HasOne(e => e.Grupo)
                    .WithMany(e => e.Eventos)
                    .HasForeignKey(e => e.IdGrupo)
                    .IsRequired();

            builder.ToTable("Eventos");
        }
    }
}