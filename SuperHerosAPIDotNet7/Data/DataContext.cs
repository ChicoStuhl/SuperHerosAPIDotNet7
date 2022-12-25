using SuperHerosAPIDotNet7.Models;

namespace SuperHerosAPIDotNet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-LL0RPFL\\SQLEXPRESS;Initial Catalog=SuperHeroDataBase;Integrated Security=SSPI ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("your_connection_string", builder =>
        //    {
        //        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        //    });
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
