using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Dominio.ModuloLocacao
{
    public interface IRepositorioLocacao : IRepositorioBase<Locacao>
    {
        Locacao SelecionarPorCondutor(Condutor condutor);
        List<Locacao> SelecionarTodos(bool incluirClienteEhVeiculo = false);
        List<Locacao> SelecionarPorStatus(EnumLocacaoStatus statusLocacao);
    }
}
