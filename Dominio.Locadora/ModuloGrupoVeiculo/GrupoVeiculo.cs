using Locadora.Dominio.Compartilhado;

namespace Locadora.Dominio.ModuloGrupoDeVeiculo
{
    public class GrupoVeiculo : EntidadeBase<GrupoVeiculo>
    {
        public GrupoVeiculo() { }
        public GrupoVeiculo(string nome)
        {
            this.Nome = nome;
        }

        public override void Atualizar(GrupoVeiculo registro)
        {
            Nome = registro.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        public string Nome { get; set; }
        
        public override bool Equals(object obj)
        {
            return obj is GrupoVeiculo grupoDeVeiculo &&
                   Nome == grupoDeVeiculo.Nome;
        }

        public GrupoVeiculo Clone()
        {
            return MemberwiseClone() as GrupoVeiculo;
        }
    }
}
