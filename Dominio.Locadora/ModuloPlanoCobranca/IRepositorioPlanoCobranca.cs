using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloGrupoDeVeiculo;

namespace Locadora.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorioBase<PlanoCobranca>
    {
        PlanoCobranca SelecionarPlanoCobrancaPorGrupoVeiculo(GrupoVeiculo grupoVeiculo);
    }
}
