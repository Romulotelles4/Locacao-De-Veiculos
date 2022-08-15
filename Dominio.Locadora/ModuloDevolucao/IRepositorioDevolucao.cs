using Locadora.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Dominio.ModuloDevolucao
{
    public interface IRepositorioDevolucao : IRepositorioBase<Devolucao>
    {
        Devolucao SelecionarPorDevolucao(Devolucao devolucao);
    }
}
