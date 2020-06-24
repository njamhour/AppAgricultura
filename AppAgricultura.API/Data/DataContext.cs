using AppAgricultura.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAgricultura.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Recurso> Recursos { get; set;}
        public DbSet<Movimentacao> Movimentacoes { get; set;}
        public DbSet<RecursoCategoria> RecursoCategorias { get; set; }

        
    }
}