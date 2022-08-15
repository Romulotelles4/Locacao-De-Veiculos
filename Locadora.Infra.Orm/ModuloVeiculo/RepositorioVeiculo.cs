using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloVeiculo;
using Locadora.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculo : IRepositorioVeiculo
    {

        private DbSet<Veiculo> veiuclos;
        private LocadoraVeiculoDbContext locadoraVeiculoDbContext;

        public RepositorioVeiculo(LocadoraVeiculoDbContext locadoraVeiculoDbContext)
        {
            veiuclos = locadoraVeiculoDbContext.Set<Veiculo>();
            this.locadoraVeiculoDbContext = locadoraVeiculoDbContext;
        }

        public void Editar(Veiculo registro)
        {
            veiuclos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            veiuclos.Remove(registro);
        }

        public Veiculo ExisteRegistroIgual(string placa)
        {
            return veiuclos.SingleOrDefault(x => x.Placa == placa);
        }

        public void Inserir(Veiculo novoRegistro)
        {
            veiuclos.Add(novoRegistro);
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return veiuclos.SingleOrDefault(x => x.Id == id);
        }

        public List<Veiculo> SelecionarTodos()
        {
            return veiuclos.ToList();
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return veiuclos.SingleOrDefault(x => x.Placa == placa);
        }
    }
}
