using System.Threading.Tasks;
using AppAgricultura.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAgricultura.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Login(string login, string senha)
        {
            //throw new System.NotImplementedException();
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == login);
            if (login == null)
                return null;

            if (!VerificaPasswordHash(senha, usuario.SenhaHash, usuario.SenhaSalt))
            return null;

            return usuario;
        }

        private bool VerificaPasswordHash(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(senhaSalt))
            {
                var hashComputado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                for (int i = 0; i < hashComputado.Length; i++)
                {
                    if (hashComputado[i] != senhaHash[i]) return false;
                }
                return true;
            }
        }

        public async Task<Usuario> Registrar(Usuario usuario, string senha)
        {
            //throw new System.NotImplementedException();
            byte[] senhaHash, senhaSalt;
            CriarSenhaHash(senha, out senhaHash, out senhaSalt);

            usuario.SenhaHash = senhaHash;
            usuario.SenhaSalt = senhaSalt;

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        public async Task<bool> UsuarioExiste(string login)
        {
            //throw new System.NotImplementedException();
            if (await _context.Usuarios.AnyAsync(x => x.Login == login))
                return true;

            return false;
        }
    }
}