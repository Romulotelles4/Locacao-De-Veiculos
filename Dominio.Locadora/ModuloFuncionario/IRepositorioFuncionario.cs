using Locadora.Dominio.Compartilhado;

namespace Locadora.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorioBase<Funcionario>
    {
        Funcionario SelecionarFuncionarioPorNome(string nome);

        Funcionario SelecionarFuncionarioPorUsuario(string usuario);
    }
}
