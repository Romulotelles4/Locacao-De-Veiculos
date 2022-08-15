using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Orm.ModuloGrupoVeiculo
{
    public class MapeadorGrupoVeiculo : IEntityTypeConfiguration<GrupoVeiculo>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculo> builder)
        {
            builder.ToTable("TBGrupoVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
        }


    }
}
