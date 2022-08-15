using Locadora.Dominio.ModuloDevolucao;
using Locadora.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Orm.ModuloDevolucao
{
    public class RepositorioDevolucao : IRepositorioDevolucao
    {
        private LocadoraVeiculoDbContext locadoraVeiculoDbContext;
        private DbSet<Devolucao> devolucoes;

        public RepositorioDevolucao(LocadoraVeiculoDbContext locadoraVeiculoDbContext)
        {
            devolucoes = locadoraVeiculoDbContext.Set<Devolucao>();
            this.locadoraVeiculoDbContext=locadoraVeiculoDbContext;
        }
        public void Editar(Devolucao registro)
        {
            devolucoes.Update(registro);
        }

        public void Excluir(Devolucao registro)
        {
            devolucoes.Remove(registro);
        }

        public void Inserir(Devolucao novoRegistro)
        {
            devolucoes.Add(novoRegistro);
        }

        public Devolucao SelecionarPorDevolucao(Devolucao devolucao)
        {
            return devolucoes.SingleOrDefault(x => x.LocacaoId == devolucao.LocacaoId);
        }

        public Devolucao SelecionarPorId(Guid id)
        {
            return devolucoes.SingleOrDefault(x => x.Id == id);
        }

        public List<Devolucao> SelecionarTodos()
        {
            return devolucoes.ToList();
        }
    }
}
