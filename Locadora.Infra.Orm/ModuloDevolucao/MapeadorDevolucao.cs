using Locadora.Dominio.ModuloDevolucao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Orm.ModuloDevolucao
{
    public class MapeadorDevolucao : IEntityTypeConfiguration<Devolucao>
    {
        public void Configure(EntityTypeBuilder<Devolucao> builder)
        {
            builder.ToTable("TbDevolucao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Locacao).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.ValorTotal).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}
