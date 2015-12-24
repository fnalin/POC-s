using AutoComplete.NomeOrCPF.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace AutoComplete.NomeOrCPF.API.Controllers
{
    public class PessoasController : ApiController
    {
        private readonly IPessoaRepo _repo;

        #region Ctor

        public PessoasController()
        {
            _repo = new PessoaRepo();
        }

        public PessoasController(IPessoaRepo repo)
        {
            _repo = repo;
        }

        #endregion

        //GET http://localhost:51882/api/Pessoas
        [Route("api/pessoas")]
        public IEnumerable<Pessoa> GetAllPessoas()
        {
            return _repo.GetAll();
        }

        //GET http://localhost:51882/api/Pessoas/GetAllAsync
        [Route("api/pessoas/getallasync")]
        public async Task<IEnumerable<Pessoa>> GetAllPessoasAsync()
        {
            return await Task.FromResult(GetAllPessoas());
        }

        //GET http://localhost:51882/api/Pessoas/GetPessoas?nome=nalin&cpf=22
        [Route("api/pessoas/getpessoas")]
        public IHttpActionResult GetPessoas(string nome = "", string cpf = "")
        {
            var pessoas = _repo.GetAll();

            if (!string.IsNullOrEmpty(nome))
                pessoas = pessoas.Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();

            if (!string.IsNullOrEmpty(cpf))
                pessoas = pessoas.Where(p => p.CPF.Contains(cpf)).ToList();

            if (pessoas == null || pessoas.Count == 0)
                return NotFound(); // Retorna NotFoundResult

            return Ok(pessoas);
        }

        //GET http://localhost:51882/api/Pessoas/GetPessoasAsync?nome=nalin&cpf=22
        [Route("api/pessoas/getpessoasasync")]
        public async Task<IHttpActionResult> GetPessoasAsync(string nome = "", string cpf = "")
        {
            return await Task.FromResult(GetPessoas(nome, cpf));
        }

    }
}
