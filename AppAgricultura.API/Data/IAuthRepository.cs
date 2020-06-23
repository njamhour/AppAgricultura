using System.Threading.Tasks;
using AppAgricultura.API.Models;

namespace AppAgricultura.API.Data
{
    public interface IAuthRepository
    {
        Task<Usuario> Registrar(Usuario usuario, string senha);
        Task<Usuario> Login(string login, string senha);
        Task<bool> UsuarioExiste(string login);
    }
}