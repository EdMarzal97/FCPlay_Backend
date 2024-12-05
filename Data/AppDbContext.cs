using Microsoft.EntityFrameworkCore;
using FCPlay.Models;

namespace FCPlay.Data {
    public class AppDbContext : DbContext {
        public required DbSet<User> Users { get; set; }
        public required DbSet<Match> Matches { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}