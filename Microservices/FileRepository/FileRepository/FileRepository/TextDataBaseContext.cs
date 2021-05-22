using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FileRepository
{
    class TextDataBaseContext : DbContext
    {
        private readonly string _connectionString;

        public TextDataBaseContext(IOptions<TextDataBaseOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<File>();
        }

        public DbSet<File> Files { get; set; }
    }
}
