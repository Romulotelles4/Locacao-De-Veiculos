using Locadora.Dominio.ModuloCliente;
using Locadora.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF", registro.Cpf);
            comando.Parameters.AddWithValue("CNPJ", registro.Cnpj);
            comando.Parameters.AddWithValue("CNH", registro.Cnh);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("TIPOCADASTRO", registro.TipoCadastro);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["CLIENTE_ID"].ToString());
            string nome = Convert.ToString(leitorRegistro["CLIENTE_NOME"]);
            string cpf = Convert.ToString(leitorRegistro["CLIENTE_CPF"]);
            string cnpj = Convert.ToString(leitorRegistro["CLIENTE_CNPJ"]);
            string cnh = Convert.ToString(leitorRegistro["CLIENTE_CNH"]);
            string endereco = Convert.ToString(leitorRegistro["CLIENTE_ENDERECO"]);
            string email = Convert.ToString(leitorRegistro["CLIENTE_EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["CLIENTE_TELEFONE"]);
            bool tipocadastro = leitorRegistro.GetBoolean(leitorRegistro.GetOrdinal("CLIENTE_TIPOCADASTRO"));

            var cliente = new Cliente
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Cnpj = cnpj,
                Cnh = cnh,
                Endereco = endereco,
                Email = email,
                Telefone = telefone,
                TipoCadastro = tipocadastro

            };
            return cliente;


        }
    }
}
