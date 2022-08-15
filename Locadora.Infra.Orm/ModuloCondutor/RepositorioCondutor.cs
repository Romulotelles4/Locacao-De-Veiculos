using Locadora.Dominio.ModuloCondutor;
using Locadora.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutor : IRepositorioCondutor
    {
        private LocadoraVeiculoDbContext locadoraVeiculoDbContext;
        private DbSet<Condutor> condutores;

        public RepositorioCondutor(LocadoraVeiculoDbContext locadoraVeiculoDbContext)
        {
            this.locadoraVeiculoDbContext=locadoraVeiculoDbContext;
            condutores = locadoraVeiculoDbContext.Set<Condutor>();
        }

        public void Inserir(Condutor novoRegistro)
        {
            condutores.Add(novoRegistro);
        }

        public void Editar(Condutor registro)
        {
            condutores.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            condutores.Remove(registro);
        }

        public Condutor SelecionarCondutorPorCliente(Guid ClienteId)
        {
            return condutores.FirstOrDefault(x => x.ClienteId == ClienteId);
        }

        public Condutor SelecionarCondutorPorCpf(string cpf)
        {
            return condutores.FirstOrDefault(x => x.Cpf == cpf);
        }

        public Condutor SelecionarPorId(Guid id)
        {
            //executa a query no banco
            return condutores.SingleOrDefault(x => x.Id == id);
        }

        public List<Condutor> SelecionarTodos()
        {
            return condutores.ToList();
        }
    }
}
