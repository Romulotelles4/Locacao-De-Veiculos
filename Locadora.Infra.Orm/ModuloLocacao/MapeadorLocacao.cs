using Locadora.Dominio.ModuloLocacao;
using Locadora.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacao : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(a => a.Funcionario).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Cliente).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Condutor).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.GrupoVeiculo).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Veiculo).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.PlanoCobranca).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Property(a => a.QuilometragemInicial).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(a => a.DataInicialLocacao).HasColumnType("date").IsRequired();
            builder.Property(a => a.DataPrevistaDevolucao).HasColumnType("date").IsRequired();
            builder.Property(a => a.Status).HasColumnType("int").IsRequired()
                .HasComment("0 == 'Aberta' \n 1 == 'Fechada' \n 2 == 'Cancelada'");
            builder.Property(a => a.TipoPlanoCobranca).HasColumnType("int").IsRequired()
                .HasComment("0 == 'Diaria' \n 1 == 'Livre' \n 2 == 'Controlada'");
            builder.HasMany(x => x.Taxas)
                .WithMany(x => x.Locacoes)
                .UsingEntity<Dictionary<string, object>>(
                    "TBLocacaoTaxa",
                    x => x.HasOne<Taxa>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    x => x.HasOne<Locacao>().WithMany().OnDelete(DeleteBehavior.Cascade)
                );
                
        }
    }
}
