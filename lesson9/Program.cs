#region Onconfiguring ile Kongigurasyon Ayarlıarını Gerçekleştirmek
// ef core tool yapılandırmak için kullandığımız mettodur.
// veri tabanına karşılık gelene context nesnesine overrride edilerek kullanılır.
#endregion
#region Basit Düzeyde Entity Tanımlama Kuralları 
//Her kolonun tablonun default olarak bir primary key kolunu olması kabul eder!
//Haliyle bu kolunu temsil eden bir property tanımlamazsa hata vericektir.
#endregion
#region  Tablo Adlarını Belirleme

#endregion
// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

#region Vei Nasıl Eklenir
//EticaretContext contex = new();
//Urun urun = new()
//{
//    UrunAdi = "A ürünü" ,
//    Fiyat = 100,
//};



#region contex.AddAsync Fonksiyonu
//await contex.AddAsync(urun); //ekleme işlemini yapar.
#endregion
#region contex.DbSet AddAsync Fonksiyonu
//await contex.Urunler.AddAsync(urun); //ekleme işlemini yapar. Tip güvenliği var bunda Urunler yazarak bu türü belirttik.
#endregion

//await contex.SaveChangesAsync(); //ekleme işlemini veri tabanına yansıtır. //ekleme güncelleme silme işlemlerinde kullanılır.Eğerki oluşturukan soruglardanbiri başarısız olursa tüm işlmeleri geri alır.

#endregion

#region Ef vore Açısında Bir verinin Eklenmesi Gerektiğini Nasıl Anlaşılıyor.

//EticaretContext context = new();
//Urun urun2 = new()
//{
//    UrunAdi = "B ürünü",
//    Fiyat = 200,
//};
//Console.WriteLine(context.Entry(urun2).State);

//await context.Urunler.AddAsync(urun2);
//Console.WriteLine(context.Entry(urun2).State); //BU STATE GÖRE hangi sorgulları çalıştrıcak anlıcak.
//await context.SaveChangesAsync();
#endregion

#region Birden Fazla Veri Eklerken Nelere Dikkat edilmeli.
//EticaretContext context = new();
//Urun urun = new()
//{
//    UrunAdi = "C ürünü",
//    Fiyat = 300,

//};

//Urun urun2 = new()
//{
//    UrunAdi = "D ürünü",
//    Fiyat = 300,
//};
//Urun urun3 = new()
//{
//    UrunAdi = "Eee ürünü",
//    Fiyat = 300,

//};
//transaction bi maliyet dir tek tek böyle yapmak yerine toplu yapmalıyız.
//await context.Urunler.AddAsync(urun);
//await context.SaveChangesAsync(); //ilk ekleme işlemi
//await context.Urunler.AddAsync(urun2);
//await context.SaveChangesAsync(); //ikinci ekleme işlemi
//await context.Urunler.AddAsync(urun3);
//await context.SaveChangesAsync(); //ucuncu ekleme işlemi
#region  SavaChanges verimli kullanma ekstradan maliyet için birden fazla veri ekleme aslında.


//2.yol daha azmaliyetli olması gerekn birden fazlada veriml,i kullanmak aslında.
//await context.Urunler.AddAsync(urun);
//await context.Urunler.AddAsync(urun2);
//await context.Urunler.AddAsync(urun3);
// await context.AddRangeAsync(urun, urun2, urun3); //toplu ekleme işlemi tek tek yazmak yerine budaolur.

/*await context.SaveChangesAsync();*/ //toplu ekleme işlemi
#endregion
#endregion

#region Eklenen Verinin Generate Id sini Elde etme

#endregion


/// <summary>
/// 
/// </summary>
/// 

#region VeriGüncelleme

#endregion

public class EticaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Provider yapılandırılması
        //connection string
        //lazyloadıngle çalışıcak mı çalışmıcak mı???? => tam anla tam anlamadım.
        optionsBuilder.UseSqlServer("Server=SERHAT\\SQLEXPRESS;Database=EticaretDB123;User Id=sa;Password=1234;TrustServerCertificate=True;");


    }

}
public class Urun
{ //hepside primary key                                        
  // public int Id { get; set; }
  // public int ID { get; set; }
  // public int UrunID { get; set; }
  // public int UrunıD { get; set; }
    public int UrunId { get; set; }
    public string UrunAdi { get; set; }
    public int Fiyat { get; set; }
}









