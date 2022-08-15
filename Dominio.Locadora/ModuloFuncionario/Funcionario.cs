using Locadora.Dominio.Compartilhado;
using System;

namespace Locadora.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Administrador { get; set; }
        public decimal Salario { get; set; }

        public DateTime DataEntrada { get; set; }

        public Funcionario() { }

        public Funcionario(string nome, string login, string senha, DateTime data, bool administrador, decimal salario)
        {
            Nome=nome;
            Login=login;
            Senha=senha;
            DataEntrada=data;
            Administrador=administrador;
            Salario=salario;
        }

        public override void Atualizar(Funcionario registro)
        {
            Nome = registro.Nome;
            Login = registro.Login;
            Senha = registro.Senha;
            DataEntrada = registro.DataEntrada;
            Administrador = registro.Administrador;
            Salario = registro.Salario;
        }

        public override bool Equals(object obj)
        {
            return obj is Funcionario Funcionario &&
                   Nome == Funcionario.Nome  &&
                   Login == Funcionario.Login  &&
                   Senha == Funcionario.Senha  &&
                   Administrador == Funcionario.Administrador  &&
                   Salario == Funcionario.Salario  &&
                   DataEntrada == Funcionario.DataEntrada;
        }

        public override string ToString()
        {
            return Nome;
        }
        public Funcionario Clone()
        {
            return MemberwiseClone() as Funcionario;
        }
    }
}
