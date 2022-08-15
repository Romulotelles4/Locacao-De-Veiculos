using Locadora.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Orm.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("TbPlanoCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.GrupoVeiculo).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.DiarioDiaria).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DiarioPorKm).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.LivreDiaria).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ControladoDiaria).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ControladoPorKm).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ControladoLimiteKm).HasColumnType("decimal(18,2)").IsRequired();

        }


    }
}
