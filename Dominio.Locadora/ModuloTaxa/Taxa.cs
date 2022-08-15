using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloLocacao;
using System.Collections.Generic;

namespace Locadora.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public Taxa(){}

        public Taxa(decimal? valor, string descricao, TipoDeCalculo? tipoDeCalculo)
        {
            Valor=valor;
            Descricao=descricao;
            TipoDeCalculo=tipoDeCalculo;
        }

        public override void Atualizar(Taxa registro)
        {
            Valor = registro.Valor;
            Descricao = registro.Descricao;
            TipoDeCalculo = registro.TipoDeCalculo;
        }
        public decimal? Valor { get; set; }

        public string Descricao { get; set; }

        public TipoDeCalculo? TipoDeCalculo { get; set; }

        public List<Locacao> Locacoes { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Taxa Taxa &&
                   Valor == Taxa.Valor &&
                   Descricao == Taxa.Descricao &&
                   TipoDeCalculo == Taxa.TipoDeCalculo;
        }
        public override string ToString()
        {
            return Descricao;
        }
        public Taxa Clone()
        {
            return MemberwiseClone() as Taxa;
        }
    }
}
