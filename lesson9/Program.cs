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





#region VeriGüncelleme
//veri tabanından o veriyi çekcezki güncellemeye tabi tutalım!***
//EticaretContext context = new();
//Urun urun = await context.Urunler.FirstOrDefaultAsync(x => x.UrunId == 3);

//if (urun == null)
//{
//    Console.WriteLine("Böyle bir ürün yok");
//}
//if (urun != null)
//{
//    urun.UrunAdi = "Güncellenmiş Ürün123";
//    urun.Fiyat = 555;
//}
//;
//context.Urunler.Update(urun); //güncelleme işlemi
//context.SaveChanges();
#endregion

#region ChangeTractor Nedir Kısaca açıklayınız.?
//context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır.
// bu takip mekanizması sayesinde context üzeriden gelen verilerle ilgili işlmeler neticesinde update yahut delete sorgularının oluşturulcağı anlaşılır.!
#endregion

#region Takip edilemyen Nesneler nasıl güncellenir?
// EticaretContext context = new(); // yyanı context de n gelmıyor takip edilmeyior.nadir olsada gerek olabilir.
//Urun urun = new Urun()
//{
//    UrunId = 3,
//    UrunAdi = "Takip Edilemeyen Nesne",
//    Fiyat = 999
//};
#endregion
#region Update Fonksiyonu
//ChangeTracker mekanizması tarafından takip edilmeyen nesnelerin güncellenmesi için kullanılır.
//Update fonk kullanabilmek için kesinlike ilgili nesende id verilmelidir.***** 
//context.Urunler.Update(urun);
//await context.SaveChangesAsync();
#endregion

#region EntityState nedir?
// Bir entity instancenın durumunu ifade eden bir referans tır.
//EticaretContext context = new();
//Urun u = new();
//Console.WriteLine(context.Entry(u).State); //detached: //bağlı değil yani context e gelmemiş.
#endregion

#region Efcore açısından bir verinin güncellenmesini Gerktiğnii nasıl anlıyoruz.
//EticaretContext context = new();
//Urun urun = await context.Urunler.FirstOrDefaultAsync(x => x.UrunId == 3);
//Console.WriteLine(context.Entry(urun).State); //Unchanged //değişmemiş VERİ TABANINDAN GELDİ VE DEĞİŞİKLİK YOK. UYUARUSU verir buray kadar yazıp bırakırsan.
//urun.UrunAdi = "Değişmiş Ürün"; //burda modified olur. state durumu.
//Console.WriteLine(context.Entry(urun).State); //Modified
//await context.SaveChangesAsync(); //burda update sorgusu oluşur.
//Console.WriteLine(context.Entry(urun).State); //Unchanged //güncelleme yapıldıktan sonra tekrar unchanged olur.
#endregion

#region Birden fazla veri güncellenirken. nelere dikkat etmeliyiz.
//EticaretContext context = new();
//var urunler = await context.Urunler.ToListAsync();
//foreach (var item in urunler) //change tracker mekanizması ile takip ediliyıor contextden gelen veri default olarak takip edilir. 
//{
//    item.UrunAdi += "*";
//// await context.SaveChangesAsync(); //böyle tek tek yaparsan maliyetli olur. savecahnges daha sonra çağır yani. allta foreachın altında yaz.
//}
//await context.SaveChangesAsync(); //toplu güncelleme işlemi
#endregion

#region Veri nasıl silinir?
//EticaretContext context = new();
//Urun urun = await context.Urunler.FindAsync(5);
//if(urun is not null)
//{
//    context.Urunler.Remove(urun);
//    await  context.SaveChangesAsync();
//}
//else
//{
//    Console.WriteLine("Böyle bir ürün yok");
//}
#endregion

#region Silme işleminde ChangeTracker'in rolu
//Change tarcker context üzerinden gelen verilerin takbiinden sorumlu mekanizmadır. Bu takip mekanizması sayesinde context üzerinden gelen verilerin ilgili işlmeler neticesinde yahut delete sorgularının oluşturulcağı anlaşılır.!
#endregion
#region Takip edilemen yani context den gelmeyen veriler nasıl siliniyor;?
//EticaretContext context = new();
//Urun u = new Urun() //idyi ccontext üzerinden almadık yani konubaşlığının matığı bu.
//{
//    UrunId = 3
//};
//context.Urunler.Remove(u); //böyle sileriz.
//context.SaveChanges(); //böyle sileriz.
#endregion
#region Entity State ilede silinir.
//EticaretContext context = new();
//Urun u = new Urun()
//{
//    UrunId = 6
//};
//context.Entry(u).State = EntityState.Deleted; //böylede silebiliriz.
//await context.SaveChangesAsync();
#endregion
#region SavecChAngesi etkili kullanalım.
//HER TETİKLEDİĞİNDE BİR TRANSİStaciıon etkilenmesinde çağırılır. birden fazla veri silinir buda yanlış bi yaklaşım bi kere çağırmaya dikkat et. performans odaklı.
#region RemoveRange birden fazla veri silme.
//EticaretContext context = new();
//List<Urun> urunler =await context.Urunler.Where(x => x.UrunId >= 14 && x.UrunId <= 16).ToListAsync(); //Iquaryble olarak gelir Ieunerable değil.
//context.Urunler.RemoveRange(urunler); //toplu silme işlemi
//await context.SaveChangesAsync();

#endregion
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









