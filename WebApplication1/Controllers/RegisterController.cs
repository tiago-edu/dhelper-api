using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("register")]
    public class RegisterController : ApiController
    {
        [HttpPost]
        public async Task<object> Register([FromBody] Usuario user)
        {
            DHelperEntities entities = new DHelperEntities();

            var usuario = new Usuario
            {

                Email = user.Email,
                Nome = user.Nome,
                Senha = user.Senha,

            };

            try
            {
                entities.Usuario.Add(user);
                await entities.SaveChangesAsync();
                return "Usuário registrado com sucesso!";
            }
            catch (DbUpdateException)
            {
                return "04X00 - Este E-mail já está cadastrado";
            }
            catch
            {
                return "04X01 - Falha interna no servidor";
            }
        }
    }
}