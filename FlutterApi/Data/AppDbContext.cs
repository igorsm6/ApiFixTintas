using Microsoft.EntityFrameworkCore;
using PimTintas.API.Models;

namespace PimTintas.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}