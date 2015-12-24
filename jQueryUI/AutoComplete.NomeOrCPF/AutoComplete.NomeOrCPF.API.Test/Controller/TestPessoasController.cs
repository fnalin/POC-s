using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoComplete.NomeOrCPF.API.Models;
using System.Collections.Generic;
using AutoComplete.NomeOrCPF.API.Controllers;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace AutoComplete.NomeOrCPF.API.Test.Controller
{
    [TestClass]
    public class TestPessoasController
    {
        [TestMethod]
        [TestCategory("PessoasController / Métodos")]
        public void GetAllPessoas_Deverá_Retornar_Todas_as_Pessoas()
        {
            var repo = new PessoaRepoTest();
            var controller = new PessoasController(repo);
            var result = controller.GetAllPessoas() as List<Pessoa>;
            Assert.AreEqual(repo.Count, result.Count);
        }

        [TestMethod]
        [TestCategory("PessoasController / Métodos")]
        public  async Task GetAllPessoasAsync_Deverá_Retornar_Todas_as_Pessoas()
        {
            var repo = new PessoaRepoTest();
            var controller = new PessoasController(repo);
            var result = await controller.GetAllPessoasAsync() as List<Pessoa>;
            Assert.AreEqual(repo.Count, result.Count);
        }

        [TestMethod]
        [TestCategory("PessoasController / Métodos")]
        public void GetPessoas_Deverá_Retornar_Todas_as_Pessoas_que_tenham_no_Nome_Nalin()
        {
            var repo = new PessoaRepoTest();
            var controller = new PessoasController(repo);
            var result = controller.GetPessoas("nalin", "22") as OkNegotiatedContentResult<IList<Pessoa>>;
            //Deve achar só o Fabiano
            Assert.AreEqual(1, result.Content.Count);
        }

        [TestMethod]
        [TestCategory("PessoasController / Métodos")]
        public async Task GetPessoasAsync_Deverá_Retornar_Todas_as_Pessoas_que_tenham_no_Nome_Nalin()
        {
            var repo = new PessoaRepoTest();
            var controller = new PessoasController(repo);
            var result = await controller.GetPessoasAsync("nalin", "22") as OkNegotiatedContentResult<IList<Pessoa>>;
            //Deve achar só o Fabiano
            Assert.AreEqual(1, result.Content.Count);
        }

        [TestMethod]
        [TestCategory("PessoasController / Métodos")]
        public void GetPessoas_Não_deverá_encontrar()
        {
            var repo = new PessoaRepoTest();
            var controller = new PessoasController(repo);
            var result = controller.GetPessoas("Pafúncio");
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }



    public class PessoaRepoTest : IPessoaRepo
    {
        public int Count { get { return _pessoas.Count; } }

        public IList<Pessoa> _pessoas
        {
            get
            {
                return new List<Pessoa> {
                    new Pessoa { Id=1,Nome="Fabiano Nalin",CPF="12263425233"},
                    new Pessoa { Id=2,Nome="Priscila Mitui",CPF="93806365989"},
                    new Pessoa { Id=3,Nome="Raphael Nalin",CPF="77056873642"},
                    new Pessoa { Id=4,Nome="Pessoa com cpf errado",CPF="1234"},
                }
                .FormatarCPF();
            }
        }

        public IList<Pessoa> GetAll()
        {
            return _pessoas;
        }
    }

}
