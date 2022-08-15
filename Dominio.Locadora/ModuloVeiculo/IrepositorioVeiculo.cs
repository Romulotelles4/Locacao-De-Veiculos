using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCarro;

namespace Locadora.Dominio.ModuloVeiculo
{
    public interface IRepositorioVeiculo : IRepositorioBase<Veiculo>
    {
        public Veiculo SelecionarVeiculoPorPlaca(string placa);
    }
}
