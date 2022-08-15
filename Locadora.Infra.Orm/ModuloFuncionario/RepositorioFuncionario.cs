using Locadora.Dominio.ModuloFuncionario;
using Locadora.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionario : IRepositorioFuncionario
    {
        private LocadoraVeiculoDbContext locadoraVeiculoDbContext;
        private DbSet<Funcionario> funcionarios;

        public RepositorioFuncionario(LocadoraVeiculoDbContext locadoraVeiculoDbContext)
        {
            funcionarios = locadoraVeiculoDbContext.Set<Funcionario>();
            this.locadoraVeiculoDbContext=locadoraVeiculoDbContext;
        }

        public void Editar(Funcionario registro)
        {
            funcionarios.Update(registro);
        }

        public void Excluir(Funcionario registro)
        {
            funcionarios.Remove(registro);
        }

        public void Inserir(Funcionario novoRegistro)
        {
            funcionarios.Add(novoRegistro);
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return funcionarios.FirstOrDefault(x => x.Nome == nome);
        }

        public Funcionario SelecionarFuncionarioPorUsuario(string usuario)
        {
            return funcionarios.FirstOrDefault(x => x.Login == usuario);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            //executa a query no banco
            return funcionarios.SingleOrDefault(x => x.Id == id);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarios.ToList();
        }
    }
}
