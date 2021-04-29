using JWTAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var list = new List<Usuario>()
            {
                new Usuario{UsuarioId = 1, Nome= "Leonardo Silva", Login = "leonardo", Senha = "123"},
                new Usuario{UsuarioId = 2, Nome= "João Gomes", Login = "jo", Senha = "456"},
                new Usuario{UsuarioId = 3, Nome= "Maria Madalena", Login = "mada", Senha = "789"}
            };

            return list;
        }

        public Usuario GetById(int id)
        {            
            return GetAll().Result.ToList().Find(x => x.UsuarioId == id);
        }
    }
}
