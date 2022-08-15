using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase<Devolucao>
    {
        public Guid LocacaoId { get; set; }
        public Locacao Locacao { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataDevolucao { get; set; }
        public decimal QuilometragemFinal { get; set; }
        
        public override void Atualizar(Devolucao registro)
        {
            throw new NotImplementedException();
        }
    }
}
