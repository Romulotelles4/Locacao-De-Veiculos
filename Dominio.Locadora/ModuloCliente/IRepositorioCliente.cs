using Locadora.Dominio.Compartilhado;

namespace Locadora.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
        Cliente SelecionarClientePorCpf(string cpf);
        Cliente SelecionarClientePorCnpj(string cnpj);
    }
}
