using Locadora.Dominio.ModuloCarro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Orm.ModuloVeiculo
{
    public class MapeadorVeiculo : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TbVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Modelo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.CapacidadeTanque).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.KmPercorrido).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.CapacidadeTanque).HasColumnType("varbinary(MAX)").IsRequired();
            builder.HasOne(x => x.GrupoDeVeiculo).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
