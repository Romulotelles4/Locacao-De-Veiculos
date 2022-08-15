using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Locadora.Aplicacao.ModuloCliente;
using Locadora.Aplicacao.ModuloCondutor;
using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Locadora.Infra.BancoDados.ModuloCliente;
using Locadora.Infra.BancoDados.ModuloCondutor;
using Locadora.Test.Service.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Service.ModuloCondutor
{
    [TestClass]
    public class ServiceCondutorTest : ServiceBaseTest
    {
        ServiceCondutor _serviceCondutor;
        ServiceCliente _serviceCliente;
        ValidadorCondutor _validadorCondutor;
        Condutor _condutor;
        Cliente _cliente;
        public ServiceCondutorTest()
        {
            _serviceCondutor= new ServiceCondutor(new RepositorioCondutor());
            _serviceCliente= new ServiceCliente(new RepositorioClienteEmBancoDeDados());
            _validadorCondutor= new ValidadorCondutor();

            _cliente = new()
            {
                Nome = "romulo",
                Cpf = "163.479.180-05",
                Cnpj = "",
                Cnh = "12345678910",
                Endereco = "lages",
                Email = "Romulo@gmail.com",
                Telefone = "4999999999",
                TipoCadastro = true
            };

            _condutor = new()
            {
                Nome = "Marcos",
                Cpf = "012.021.959-03",
                Cnh = "12345678910",
                Endereco = "Rua teste - lages",
                Email = "condutor@dirigir.com",
                Telefone = "49999990000",
                Cliente = _cliente
            };
            LimparTabela("TBCLIENTE");
        }

        protected override string NomeTabela => "TBCONDUTOR";

        [TestMethod]
        public void Nao_deve_editar_condutor_com_cpf_e_cliente_cliente_igual_ja_cadastrado()
        {
            //range
            var novoCondutor = new Condutor("Joao da silva", "012.021.959-03","13246579810","Rua teste","teste@teste.com","49999990000", _cliente);

            //action
            _serviceCliente.Inserir(_cliente);
            _serviceCondutor.Inserir(_condutor);
            var resultado = _serviceCondutor.Editar(novoCondutor);

            //assert
            Assert.AreEqual("Campos com '*' precisam ser únicos", resultado.Errors[0].ErrorMessage);   
        }

        [TestMethod]
        public void Nao_deve_editar_condutor_com_atributos_nulos()
        {
            //range
            _serviceCliente.Inserir(_cliente);
            _serviceCondutor.Inserir(_condutor);
            var novoCondutor = new Condutor();
            
            //action
            _condutor.Atualizar(novoCondutor);

            var resultado = _serviceCondutor.Editar(_condutor);

            //assert
            Assert.AreEqual("O campo 'Nome' não pode ser nulo!", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Nome' não pode ser vazio!", resultado.Errors[1].ErrorMessage);
            Assert.AreEqual("O campo 'Endereço' não pode ser nulo!", resultado.Errors[2].ErrorMessage);
            Assert.AreEqual("O campo 'Endereço' não pode ser vazio!", resultado.Errors[3].ErrorMessage);
            Assert.AreEqual("O campo 'Telefone' não pode ser nulo!", resultado.Errors[4].ErrorMessage);
            Assert.AreEqual("O campo 'Telefone' não pode ser vazio!", resultado.Errors[5].ErrorMessage);
            Assert.AreEqual("O campo 'Email' não pode ser nulo!", resultado.Errors[6].ErrorMessage);
            Assert.AreEqual("O campo 'Email' não pode ser vazio!", resultado.Errors[7].ErrorMessage);
            Assert.AreEqual("O campo 'Cpf' não pode ser nulo!", resultado.Errors[8].ErrorMessage);
            Assert.AreEqual("O campo 'Cpf' não pode ser vazio!", resultado.Errors[9].ErrorMessage);
            Assert.AreEqual("Formato do campo 'Cpf' inválido!", resultado.Errors[10].ErrorMessage);
            Assert.AreEqual("O campo 'Cnh' não pode ser nulo!", resultado.Errors[11].ErrorMessage);
            Assert.AreEqual("O campo 'Cnh' não pode ser vazio!", resultado.Errors[12].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_inserir_condutor_com_cpf_igual_para_mesmo_cliente()
        {
            //range
            var novoCondutor = _condutor.Clone();

            //action
            _serviceCliente.Inserir(_cliente);
            _serviceCondutor.Inserir(_condutor);
            var resultado = _serviceCondutor.Inserir(novoCondutor);

            //assert
            Assert.AreEqual("Campos com '*' precisam ser únicos", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_deve_inserir_condutor_com_atributos_nulos()
        {
            //range
            var novoCondutor = new Condutor();

            //action
            var resultado = _serviceCondutor.Inserir(novoCondutor);


            //assert
            Assert.AreEqual("O campo 'Nome' não pode ser nulo!", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Nome' não pode ser vazio!", resultado.Errors[1].ErrorMessage);
            Assert.AreEqual("O campo 'Endereço' não pode ser nulo!", resultado.Errors[2].ErrorMessage);
            Assert.AreEqual("O campo 'Endereço' não pode ser vazio!", resultado.Errors[3].ErrorMessage);
            Assert.AreEqual("O campo 'Telefone' não pode ser nulo!", resultado.Errors[4].ErrorMessage);
            Assert.AreEqual("O campo 'Telefone' não pode ser vazio!", resultado.Errors[5].ErrorMessage);
            Assert.AreEqual("O campo 'Email' não pode ser nulo!", resultado.Errors[6].ErrorMessage);
            Assert.AreEqual("O campo 'Email' não pode ser vazio!", resultado.Errors[7].ErrorMessage);
            Assert.AreEqual("O campo 'Cpf' não pode ser nulo!", resultado.Errors[8].ErrorMessage);
            Assert.AreEqual("O campo 'Cpf' não pode ser vazio!", resultado.Errors[9].ErrorMessage);
            Assert.AreEqual("Formato do campo 'Cpf' inválido!", resultado.Errors[10].ErrorMessage);
            Assert.AreEqual("O campo 'Cnh' não pode ser nulo!", resultado.Errors[11].ErrorMessage);
            Assert.AreEqual("O campo 'Cnh' não pode ser vazio!", resultado.Errors[12].ErrorMessage);
        }

        [TestMethod]
        public void Deve_excluir_condutor_()
        {
            //action
            _serviceCliente.Inserir(_cliente);
            _serviceCondutor.Inserir(_condutor);

            _serviceCondutor.Excluir(_condutor);

            var usuarioEncontrado = _serviceCondutor.SelecionarPorId(_condutor.Id);

            //assert
            Assert.AreEqual(null, usuarioEncontrado);
        }
    }
}
