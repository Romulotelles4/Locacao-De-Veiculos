using Locadora.Dominio.Compartilhado;

namespace Locadora.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorioBase<Taxa>
    {
        Taxa SelecionarTaxaPorDescricao(string descricao);
    }
}
