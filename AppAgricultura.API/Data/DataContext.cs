using AppAgricultura.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAgricultura.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        
        public DbSet<Usuario> Usuarios { get; set; }    
        
    }
}