using Barbearia.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Agendamento> Agendamentos { get; set; }
    }
}