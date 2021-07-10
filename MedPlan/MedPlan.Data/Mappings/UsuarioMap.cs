using MedPlan.Domain.Interfaces.Configuracao;
using MedPlan.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedPlan.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.CPF)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(25)");

            builder.Property(u => u.Tipo)
                .IsRequired()
                .HasColumnType("varchar(13)");

            builder.ToTable("Usuarios");
        }
    }
}
