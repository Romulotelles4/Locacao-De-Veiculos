
using Locadora.Dominio.ModuloCondutor;
using Locadora.Dominio.ModuloLocacao;
using Locadora.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : IRepositorioLocacao
    {
        private DbSet<Locacao> locacao;
        private LocadoraVeiculoDbContext locadoraVeiculoDbContext;
        public RepositorioLocacaoOrm(LocadoraVeiculoDbContext locadoraVeiculoDbContext)
        {
            locacao = locadoraVeiculoDbContext.Set<Locacao>();
            this.locadoraVeiculoDbContext = locadoraVeiculoDbContext;
        }
        public void Editar(Locacao registro)
        {
            locacao.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            locacao.Remove(registro);
        }

        public void Inserir(Locacao novoRegistro)
        {
            locacao.Add(novoRegistro);
        }

        public Locacao SelecionarPorCondutor(Condutor condutor)
        {
            return null;
        }

        public Locacao SelecionarPorId(Guid id)
        {
            return locacao.SingleOrDefault(x => x.Id == id);
        }

        public List<Locacao> SelecionarPorStatus(EnumLocacaoStatus statusLocacao)
        {
            return locacao.ToList().FindAll(x => x.Status == statusLocacao);
        }

        public List<Locacao> SelecionarTodos()
        {
            return locacao.ToList();
        }

        public List<Locacao> SelecionarTodos(bool incluirClienteEhVeiculo = false)
        {
            if(incluirClienteEhVeiculo == true)
                return locacao
                    .Include(x => x.Cliente)
                    .Include(x => x.Veiculo)
                    .ToList();

            return locacao.ToList();
        }
    }
}
