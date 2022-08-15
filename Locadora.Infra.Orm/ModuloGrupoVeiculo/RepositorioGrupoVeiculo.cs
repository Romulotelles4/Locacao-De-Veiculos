using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infra.Orm.ModuloGrupoVeiculo
{
    public class RepositorioGrupoVeiculo : IRepositorioGrupoVeiculo
    {
        private DbSet<GrupoVeiculo> grupoVeiculos;
        private LocadoraVeiculoDbContext locadoraVeiculoDbContext;

        public RepositorioGrupoVeiculo(LocadoraVeiculoDbContext locadoraVeiculoDbContext)
        {
            grupoVeiculos = locadoraVeiculoDbContext.Set<GrupoVeiculo>();
            this.locadoraVeiculoDbContext = locadoraVeiculoDbContext;
        }


        public void Editar(GrupoVeiculo registro)
        {
            grupoVeiculos.Update(registro);
        }

        public void Excluir(GrupoVeiculo registro)
        {
            grupoVeiculos.Remove(registro);
        }

        public void Inserir(GrupoVeiculo novoRegistro)
        {
            grupoVeiculos.Add(novoRegistro);
        }

        public GrupoVeiculo SelecionarPorId(Guid id)
        {
            return grupoVeiculos.SingleOrDefault(x => x.Id == id);
        }

        public GrupoVeiculo SelecionarGrupoVeiculoPorNome(string nome)
        {
            return grupoVeiculos.SingleOrDefault(x => x.Nome == nome);
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            return grupoVeiculos.ToList();
        }
    }
}
