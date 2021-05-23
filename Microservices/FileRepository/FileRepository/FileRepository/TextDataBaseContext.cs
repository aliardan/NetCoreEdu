using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

[assembly: InternalsVisibleTo("FileDataBaseMigrator")]
namespace TextRepository
{
    internal class TextDataBaseContext : DbContext
    {
        private readonly string _connectionString;

        [Obsolete("WorkAround for EFCore Migrations generation")]
        public TextDataBaseContext()
        {
            _connectionString = "PlaceHolder";
        }

        public TextDataBaseContext(IOptions<TextDataBaseOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var migrationsAssembly = Assembly.GetExecutingAssembly().GetName().Name;
            optionsBuilder.UseNpgsql(_connectionString, x => x.MigrationsAssembly(migrationsAssembly));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Text>();
        }

        public DbSet<Text> Files { get; set; }
    }
}
