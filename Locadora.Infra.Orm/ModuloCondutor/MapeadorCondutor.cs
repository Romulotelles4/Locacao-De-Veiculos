using Locadora.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Orm.ModuloCondutor
{
    public class MapeadorCondutor : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("varchar(14)").IsRequired();
            builder.Property(x => x.Cnh).HasColumnType("varchar(11)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(18)").IsRequired();
            builder.HasOne(x => x.Cliente).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
