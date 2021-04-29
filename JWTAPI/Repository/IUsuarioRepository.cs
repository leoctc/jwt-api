using JWTAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWTAPI.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();

       Usuario GetById(int id);
    }
}
