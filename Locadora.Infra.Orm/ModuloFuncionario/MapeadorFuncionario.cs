using Locadora.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionario : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Login).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Administrador).HasColumnType("bit").IsRequired();
            builder.Property(x => x.Salario).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DataEntrada).HasColumnType("date").IsRequired();
        }
    }
}
