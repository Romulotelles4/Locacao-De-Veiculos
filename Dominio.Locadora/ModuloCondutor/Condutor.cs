using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCliente;
using System;

namespace Locadora.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Condutor(string nome, string cpf, string cnh, string endereco, string email, string telefone, Cliente cliente)
        {
            Nome=nome;
            Cpf=cpf;
            Cnh=cnh;
            Endereco=endereco;
            Email=email;
            Telefone=telefone;
            Cliente=cliente;
        }

        public Condutor()
        {
            Cliente = new Cliente();
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public override void Atualizar(Condutor registro)
        {
            Nome = registro.Nome;
            Cpf = registro.Cpf;
            Cnh = registro.Cnh;
            Endereco = registro.Endereco;
            Email = registro.Email;
            Telefone = registro.Telefone;
            AtualizarCliente(registro);
        }

        private void AtualizarCliente(Condutor registro)
        {
            Cliente.Atualizar(registro.Cliente);
            Cliente.Id = registro.Cliente.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Condutor condutor &&
                   Nome == condutor.Nome &&
                   Cpf == condutor.Cpf &&
                   Cnh == condutor.Cnh &&
                   Endereco == condutor.Endereco &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   Cliente.Equals(condutor.Cliente);
        }
        public Condutor Clone()
        {
            return MemberwiseClone() as Condutor;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
