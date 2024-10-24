using Microsoft.EntityFrameworkCore;
using Trabajo_Api.Models;

namespace Trabajo_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
