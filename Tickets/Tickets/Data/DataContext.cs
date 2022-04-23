using Microsoft.EntityFrameworkCore;
using Tickets.Data.Entities;

namespace Tickets.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public IEnumerable<object> Entrance { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
