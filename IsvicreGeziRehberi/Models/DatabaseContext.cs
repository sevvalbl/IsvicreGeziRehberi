using Microsoft.EntityFrameworkCore;




namespace IsvicreGeziRehberi.Model
{
    public class DatabaseContext:DbContext
    {
        public DbSet<GonderiKategori> GonderiKategoris { get; set; }
        public DbSet<Gonderi> Gonderis { get; set; }
        public DbSet<KullaniciRolu> KullaniciRolus { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=IsvicreBlog;integrated security=true;");
            base.OnConfiguring(optionsBuilder); 

        }
    }
}
