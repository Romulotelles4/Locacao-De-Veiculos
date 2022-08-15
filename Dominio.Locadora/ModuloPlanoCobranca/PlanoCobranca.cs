using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using System;

namespace Locadora.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public GrupoVeiculo GrupoVeiculo { get; set; }
        public Guid GrupoVeiculoId { get; set; }
        public decimal DiarioDiaria { get; set; }
        public decimal DiarioPorKm { get; set; }
        public decimal LivreDiaria { get; set; }
        public decimal ControladoDiaria { get; set; }
        public decimal ControladoPorKm { get; set; }
        public decimal ControladoLimiteKm { get; set; }


        public PlanoCobranca() 
        {
            GrupoVeiculo = new GrupoVeiculo();
        }

        public PlanoCobranca(GrupoVeiculo grupoVeiculo, decimal diarioDiaria, decimal diarioPorKm, decimal livreDiaria, decimal controladoDiaria, decimal controladoPorKm, decimal controladoLimiteKm)
        {
            GrupoVeiculo = grupoVeiculo;
            DiarioDiaria  = diarioDiaria;
            DiarioPorKm = diarioPorKm;
            LivreDiaria = livreDiaria;
            ControladoDiaria = controladoDiaria;
            ControladoPorKm = controladoPorKm;
            ControladoLimiteKm = controladoLimiteKm;
        }

        public override void Atualizar(PlanoCobranca registro)
        {
            DiarioDiaria = registro.DiarioDiaria;
            DiarioPorKm = registro.DiarioPorKm;
            LivreDiaria = registro.LivreDiaria;
            ControladoDiaria = registro.ControladoDiaria;
            ControladoPorKm = registro.ControladoPorKm;
            ControladoLimiteKm = registro.ControladoLimiteKm;
            AtualizarGrupoVeiculo(registro);
        }

        public PlanoCobranca Clone()
        {
            return MemberwiseClone() as PlanoCobranca;
        }

        public override bool Equals(object obj)
        {
            return obj is PlanoCobranca cobranca &&
                   GrupoVeiculo.Equals(cobranca.GrupoVeiculo) &&
                   DiarioDiaria == cobranca.DiarioDiaria &&
                   DiarioPorKm == cobranca.DiarioPorKm &&
                   LivreDiaria == cobranca.LivreDiaria &&
                   ControladoDiaria == cobranca.ControladoDiaria &&
                   ControladoPorKm == cobranca.ControladoPorKm &&
                   ControladoLimiteKm == cobranca.ControladoLimiteKm;
        }

        public override string ToString()
        {
            return "Taxa "+GrupoVeiculo.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GrupoVeiculo, DiarioDiaria, DiarioPorKm, LivreDiaria, ControladoDiaria, ControladoPorKm, ControladoLimiteKm);
        }
        #region métodos privados
        private void AtualizarGrupoVeiculo(PlanoCobranca registro)
        {
            GrupoVeiculo.Atualizar(registro.GrupoVeiculo);
            GrupoVeiculo.Id = registro.GrupoVeiculo.Id;
        }
        #endregion
    }
}
