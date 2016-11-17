using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebApiOwin.Controllers
{
    public class TesteController : ApiController
    {

        //public IHttpActionResult Get()
        //{
        //    var data = new
        //    {
        //        Nome = "Fabiano Nalin",
        //        Idade = 37,
        //        Cargo = "Developer"
        //    };

        //    if (data == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(data);
        //}

        public HttpResponseMessage Get()
        {
            var data = new
            {
                Nome = "Fabiano Nalin",
                Idade = 37,
                Cargo = "Developer"
            };

            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}

