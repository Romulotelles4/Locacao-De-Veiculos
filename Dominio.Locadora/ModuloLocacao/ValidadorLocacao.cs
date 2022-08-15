using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.DataInicialLocacao)
                .NotEmpty().WithMessage("O campo 'Data inicial locação' é obrigatório!")
                .NotNull().WithMessage("O campo 'Data inicial locação' é obrigatório!")
                .Must(DataDeveSerMaiorIgualDataAtual).WithMessage("Data inicial deve ser igual ou maior que data atual");

            RuleFor(x => x.DataPrevistaDevolucao)
                .NotEmpty().WithMessage("O campo 'Data prevista devolução' é obrigatório!")
                .NotNull().WithMessage("O campo 'Data prevista devolução' é obrigatório!")
                .Must(DataDeveSerMaiorIgualDataAtual).WithMessage("Data prevista para devolução deve ser igual ou maior que data atual")
                .GreaterThan(x => x.DataInicialLocacao).WithMessage("O campo 'Salário' deve ser maior que 0 (zero)!");

            RuleFor(x => x.QuilometragemInicial)
                .NotEmpty().WithMessage("O campo 'Quilometragem inicial' é obrigatório!")
                .NotNull().WithMessage("O campo 'Quilometragem inicial' é obrigatório!")
                .GreaterThan(0).WithMessage("O campo 'Quilometragem inicial' deve ser maior que 0 'Zero'!");

        }

        public bool DataDeveSerMaiorIgualDataAtual(DateTime data)
        {
            if(DateTime.Now.Date <= data)
                return true;
            
            return false;
        }
    }
}
