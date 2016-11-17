using DemoWebApiOwin.Data;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoWebApiOwin.Controllers
{
    public class EmployeesController : ApiController
    {

        private readonly IEmployeeRepository _repo;
        public EmployeesController()
        {
            _repo = new EmployeeRepository();
        }

        //Retorna síncrono
        //public IHttpActionResult Get()
        //{
        //    return Ok( _repo.GetAll());
        //}

        //Retorna assíncrono com um método síncrono dentro
        //public async Task<IHttpActionResult> Get()
        //{
        //    var emps = Task.Run(() =>
        //    {
        //        return _repo.GetAll();
        //    });

        //    return Ok(await emps);
        //}

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _repo.GetAllAsync());
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                return Content(HttpStatusCode.NotFound, "Resource Not Found");

            return Ok(data);
        }

        public async Task<IHttpActionResult> Post([FromBody] Employee emp)
        {
            return Ok(await _repo.AddAsync(emp));
        }

        public async Task<IHttpActionResult> Put(int id, [FromBody] Employee emp)
        {
            var data = await _repo.UpdateAsync(emp);

            if (data == null)
                return Content(HttpStatusCode.BadRequest, "Resource Invalid");

            return Ok(data);
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            var data = await _repo.DeleteAsync(id);

            if (data == null)
                return Content(HttpStatusCode.NotFound, "Resource Not Found");

            return Ok(data);
        }


    }
}