using Locadora.Dominio.ModuloCondutor;
using Locadora.Infra.BancoDados.Compartilhado;
using Locadora.Infra.BancoDados.ModuloCliente;
using System;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        MapeadorCliente mapeadorCliente;
        public MapeadorCondutor()
        {
            mapeadorCliente = new MapeadorCliente();
        }
        public override void ConfigurarParametros(Condutor registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF", registro.Cpf);
            comando.Parameters.AddWithValue("CNH", registro.Cnh);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("CLIENTE_ID", registro.Cliente.Id);

        }

        public override Condutor ConverterRegistro(SqlDataReader leitorRegistro)
        {
            Guid id = Guid.Parse(leitorRegistro["CONDUTOR_ID"].ToString());
            string nome = Convert.ToString(leitorRegistro["CONDUTOR_NOME"]);
            string cpf = Convert.ToString(leitorRegistro["CONDUTOR_CPF"]);
            string cnh = Convert.ToString(leitorRegistro["CONDUTOR_CNH"]);
            string endereco = Convert.ToString(leitorRegistro["CONDUTOR_ENDERECO"]);
            string email = Convert.ToString(leitorRegistro["CONDUTOR_EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["CONDUTOR_TELEFONE"]);
            var cliente = mapeadorCliente.ConverterRegistro(leitorRegistro);

            var condutor = new Condutor
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Cnh = cnh,
                Endereco = endereco,
                Email = email,
                Telefone = telefone,
                Cliente = cliente

            };

            return condutor;
        }
    }
}
