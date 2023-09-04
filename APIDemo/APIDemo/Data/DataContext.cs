
namespace APIDemo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=VIV\\SQLEXPRESS;Database=APIDemodb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        //superhero property db set
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
