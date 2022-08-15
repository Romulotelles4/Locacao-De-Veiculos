using Locadora.Dominio.ModuloCliente;
using Locadora.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infra.Orm.ModuloCliente
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private LocadoraVeiculoDbContext locadoraVeiculoDbContext;
        private DbSet<Cliente> cliente;

        public RepositorioCliente(LocadoraVeiculoDbContext locadoraVeiculoDbContext)
        {
            cliente = locadoraVeiculoDbContext.Set<Cliente>();
            this.locadoraVeiculoDbContext = locadoraVeiculoDbContext;
        }

        public void Editar(Cliente registro)
        {
            cliente.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            cliente.Remove(registro);
        }

        public void Inserir(Cliente novoRegistro)
        {
            cliente.Add(novoRegistro);
        }

        public Cliente SelecionarClientePorCnpj(string cnpj)
        {
            return cliente.SingleOrDefault(x => x.Cnpj == cnpj);
        }

        public Cliente SelecionarClientePorCpf(string cpf)
        {
            return cliente.SingleOrDefault(x => x.Cpf == cpf);
        }

        public Cliente SelecionarPorId(Guid id)
        {
            return cliente.SingleOrDefault(x => x.Id == id);
        }

        public List<Cliente> SelecionarTodos()
        {
            return cliente.ToList();
        }
    }
}
