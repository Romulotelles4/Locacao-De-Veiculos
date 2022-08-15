using FluentAssertions;
using Locadora.Dominio.ModuloFuncionario;
using Locadora.Infra.BancoDados.ModuloFuncionario;
using Locadora.Test.Infra.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Locadora.Test.Infra.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioBancoDadosTest : RepositorioBaseTest
    {
        private RepositorioFuncionarioBancoDados repositorio;

        protected override string NomeTabela => "TbFuncionario";

        public RepositorioFuncionarioBancoDadosTest()
        {
            repositorio = new RepositorioFuncionarioBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_funcionario()
        {
            //arrange
            var fornecedor = NovoFuncionario();

            //action
            repositorio.Inserir(fornecedor);

            //assert
            var fornecedorEncontrado = repositorio.SelecionarPorId(fornecedor.Id);

            fornecedorEncontrado.Should().NotBeNull();
            fornecedorEncontrado.Should().Be(fornecedor);
        }

        [TestMethod]
        public void Deve_editar_informacoes_funcionario()
        {
            //arrange
            var fornecedor = NovoFuncionario();
            repositorio.Inserir(fornecedor);

            fornecedor.Nome = "Joao editado";
            fornecedor.Login = "joaologin";
            fornecedor.Senha = "joaosenha";
            fornecedor.DataEntrada = new DateTime(2022, 03, 03);

            //action
            repositorio.Editar(fornecedor);

            //assert
            var fornecedorEncontrado = repositorio.SelecionarPorId(fornecedor.Id);

            fornecedorEncontrado.Should().NotBeNull();
            fornecedorEncontrado.Should().Be(fornecedor);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange           
            var funcionario = NovoFuncionario();
            repositorio.Inserir(funcionario);

            //action           
            repositorio.Excluir(funcionario);

            //assert
            repositorio.SelecionarPorId(funcionario.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_funcionario()
        {
            //arrange          
            var funcionario = NovoFuncionario();
            repositorio.Inserir(funcionario);

            //action
            var fornecedorEncontrado = repositorio.SelecionarPorId(funcionario.Id);

            //assert
            Assert.IsNotNull(fornecedorEncontrado);
            Assert.AreEqual(funcionario, fornecedorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_fornecedores()
        {
            //arrange
            var f0 = new Funcionario("Usuário master", "Admin1", "Admin1", new DateTime(2022, 01, 01), false, 50.00m);
            var f1 = new Funcionario("Ze da pastelaria", "zezeze", "zezeze", new DateTime(2022, 02, 02), false, 50.00m);
            var f2 = new Funcionario("Joao da borracharia", "joaobr", "joaobr", new DateTime(2022, 03, 03), false, 50.00m);

            repositorio.Inserir(f0);
            repositorio.Inserir(f1);
            repositorio.Inserir(f2);

            //action
            var fornecedores = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, fornecedores.Count);

            Assert.AreEqual(f0.Nome, fornecedores[0].Nome);
            Assert.AreEqual(f1.Nome, fornecedores[1].Nome);
            Assert.AreEqual(f2.Nome, fornecedores[2].Nome);
            LimparTabela("TBFUNCIONARIO");
        }

        //[TestMethod]
        //public void Nao_deve_inserir_funcionario_duplicado()
        //{
        //    //arrange
        //    var fornecedor = NovoFuncionario();

        //    //action
        //    repositorio.Inserir(fornecedor);

        //    repositorio.Inserir(fornecedor);

        //    var fornecedorEncontrado = repositorio.SelecionarTodos();

        //    //assert
        //    Assert.AreEqual(1, fornecedorEncontrado.Count);
        //}

        [TestMethod]
        public void Nao_deve_ditar_funcionario_com_nome_e_login_igual_outro_registro()
        {
            ////arrange
            //var f0 = new Funcionario("Usuário master", "Admin1", "Admin1", new DateTime(2022, 01, 01), false, 50.00m);
            //var f1 = new Funcionario("Ze da pastelaria", "zezeze", "zezeze", new DateTime(2022, 02, 02), false, 50.00m);

            ////action
            //repositorio.Inserir(f0);

            //repositorio.Inserir(f1);

            //f0.Nome = "Ze da pastelaria";
            //f0.Login = "zezeze";

            //var resultado = repositorio.Editar(f0);

            ////assert
            //Assert.AreEqual(false, resultado.IsValid);
        }

        private Funcionario NovoFuncionario()
        {
            return new Funcionario("Usuário master", "Admin1", "Admin1", new DateTime(2022, 01, 01), false, 50.00m);
        }
    }
}
