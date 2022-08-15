using Locadora.Dominio.Compartilhado;
using System;

namespace Locadora.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorioBase<Condutor>
    {
        Condutor SelecionarCondutorPorCliente(Guid ClienteId);
        Condutor SelecionarCondutorPorCpf(string cpf);
    }
}
