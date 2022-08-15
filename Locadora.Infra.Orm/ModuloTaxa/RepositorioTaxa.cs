using Locadora.Dominio.ModuloTaxa;
using Locadora.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxa : IRepositorioTaxa
    {
        private DbSet<Taxa> taxas;
        private LocadoraVeiculoDbContext locadoraVeiculoDbContext;

        public RepositorioTaxa(LocadoraVeiculoDbContext locadoraVeiculoDbContext)
        {
            taxas = locadoraVeiculoDbContext.Set<Taxa>();
            this.locadoraVeiculoDbContext = locadoraVeiculoDbContext;
        }

        public void Editar(Taxa registro)
        {
            taxas.Update(registro);
        }

        public void Excluir(Taxa registro)
        {
            taxas.Remove(registro);
        }

        public void Inserir(Taxa novoRegistro)
        {
            taxas.Add(novoRegistro);
        }

        public Taxa SelecionarPorId(Guid id)
        {
            return taxas.SingleOrDefault(x => x.Id == id);
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return taxas.SingleOrDefault(x => x.Descricao == descricao);
        }

        public List<Taxa> SelecionarTodos()
        {
            return taxas.ToList();
        }
    }
}
