using MedPlan.Domain.Interfaces.Configuracao;
using MedPlan.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedPlan.Data.Mappings
{
    public class ProcedimentoMap : IEntityTypeConfiguration<Procedimento>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Procedimento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            //builder.HasMany(m => m.Medicos)
            //   .WithOne(p => p.Procedimento)
            //   .HasForeignKey(p => p.ProcedimentoId);

            builder.ToTable("Procedimentos");
        }
    }
}
