using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using AutoComplete.NomeOrCPF.API.Models;
using Moq;

namespace AutoComplete.NomeOrCPF.API.Test.Repositorio
{
    [TestClass]
    public class TestPessoaRepo
    {
        [TestMethod]
        [TestCategory("PessoaRepo / Mock")]
        public void PessoaRepo_Verificando_o_Comportamento_do_GetAll()
        {
            //arrange
            var mockRep = new Mock<IPessoaRepo>();
            mockRep.Setup(mr => mr.GetAll()).Returns(pessoasStub);

            //act
            var dados = mockRep.Object.GetAll();

            //assert
            Assert.IsNotNull(dados); // testando se tá nulo
            Assert.AreEqual(3, dados.Count); // comparando o n. de itens
        }

        [TestMethod]
        [TestCategory("PessoaRepo / Mock")]
        public void PessoaRepo_Verificando_o_Comportamento_do_Count()
        {
            var mockRep = new Mock<IPessoaRepo>();
            mockRep.Setup(mr => mr.Count).Returns(pessoasStub().Count);

            var contando = mockRep.Object.Count;

            Assert.IsNotNull(contando);
            Assert.AreEqual(3, contando);
        }

        private IList<Pessoa> pessoasStub()
        {
            return new List<Pessoa> {
                new Pessoa { Id=1,Nome="Fabiano Nalin",CPF="12263425233"},
                    new Pessoa { Id=2,Nome="Priscila Mitui",CPF="93806365989"},
                    new Pessoa { Id=3,Nome="Raphael Nalin",CPF="77056873642"},
            };
        }
    }
}
