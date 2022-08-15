using Locadora.Dominio.Compartilhado;

namespace Locadora.Dominio.ModuloGrupoDeVeiculo
{
    public interface IRepositorioGrupoVeiculo : IRepositorioBase<GrupoVeiculo>
    {
        GrupoVeiculo SelecionarGrupoVeiculoPorNome(string nome);
    }
}
