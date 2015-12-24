using AutoComplete.NomeOrCPF.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AutoComplete.NomeOrCPF.API.Controllers
{
    public class PessoasController : ApiController
    {
        private IList<Pessoa> _pessoas
        {
            get
            {
                return new List<Pessoa> {
                    new Pessoa { Id=1,Nome="Fabiano Nalin",CPF="12263425233"},
                    new Pessoa { Id=2,Nome="Priscila Mitui",CPF="93806365989"},
                    new Pessoa { Id=3,Nome="Raphael Nalin",CPF="77056873642"},
                    new Pessoa { Id=3,Nome="Rafael Pereira de Goes",CPF="58133513707"},
                };
            }
        }

        public IHttpActionResult Get(string nome = "", string cpf = "")
        {
            var pessoas = _pessoas;

            if (nome.Length > 0)
                pessoas = pessoas.Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();

            if (cpf.Length > 0)
                pessoas = pessoas.Where(p => p.CPF.Contains(cpf)).ToList();

            if (pessoas == null)
                return NotFound(); // Retorna NotFoundResult

            return Ok(pessoas);

        }
    }
}
