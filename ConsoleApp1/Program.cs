using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello, World!");




public class DB1 : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Kategory> Kategories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
      "Server=SERHAT\\SQLEXPRESS;Database=deneme123;User Id=sa;Password=1234;TrustServerCertificate=True;");
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Kategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptıon { get; set; }
    }
}