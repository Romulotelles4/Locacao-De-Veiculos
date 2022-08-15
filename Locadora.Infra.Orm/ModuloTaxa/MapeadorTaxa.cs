using Locadora.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Orm.ModuloTaxa
{
    public class MapeadorTaxa : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTaxa");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Descricao).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.TipoDeCalculo).HasConversion<int>();
            builder.Property(x => x.Valor).HasColumnType("decimal(18,2)").IsRequired();

        }
    }
}
