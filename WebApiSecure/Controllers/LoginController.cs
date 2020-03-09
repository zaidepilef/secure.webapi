using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using WebApiSecure.Model;

namespace WebApiSecure.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        bool existeEmpresa = false;
        Cliente clienteEmprea = new Cliente();

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {

            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (login.ApiKey == "1234")// valida si existe 
            {
                Cliente cli = new Cliente();
                cli.api_key = "1234";
                cli.id_empresa = "ID-1234";
                cli.url_empresa = "comparaseguro.com";
                cli.nombre_empresa = "Cotiza Seguros Online Ecuador";
                var token = TokenGenerator.GenerateTokenJwt(cli);
                return Ok(token);
            }
            else
            {
                return Unauthorized();

            }
        }

    }
}
