using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("update-user")]
    public class ModificationAccountController : ApiController
    {
        public async Task<object> Change([FromBody] Usuario user)
        {

           DHelperEntities entitie = new DHelperEntities();

            try
            {
                var usuario = entitie
                    .Usuario
                    .First(x => x.ID == user.ID);

                usuario.Email = user.Email;
                usuario.Senha = user.Senha;

                await entitie.SaveChangesAsync();

                return "Alterações realizadas com sucesso!";
            }
            catch (DbUpdateException)
            {
                return "01X04 - Não foi possível alterar as informações de usuário";
            }
            catch
            {
                return "01X05 - Falha interna no servidor";
            }
        }
    }
}