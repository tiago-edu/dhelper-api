using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [Route("login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        public async Task<object> Login([FromBody] Usuario user)
        {

            DHelperEntities entitie = new DHelperEntities();

            var usuario = entitie.Usuario.FirstOrDefault(x => x.Email == user.Email);

            if (user == null)
                return "Usuário ou senha incorretos";
            else if (usuario.Senha == user.Senha)
            {
                return "Login feito com sucesso";
            }
            else
                return "Usuário ou senha incorretos";
        }

    }
}