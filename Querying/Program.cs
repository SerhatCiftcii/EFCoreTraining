// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello, World!");

EticaretContext context = new();
#region En temel basit bir sorgulama nasıl yapılır.
#region Method Syntax
//var urunler = await context.Urunler.ToListAsync(); //METHOD syntax oldu => buda link sorgu
#endregion
#region Query Syntax
//yine urunleri çkecez ama bu sefer query syntax ile bu alltaki sorgu linq query
//var urunler2 = await (from urun in context.Urunler
//               select urun).ToListAsync(); //query syntax oldu c# sorgusu tolist dedikten sonra ama oan ıenumareble olur. mantık bu
#endregion
#endregion

#region Sorguyu Execute Etmek için Ne Yapmamız gerekir?
//int urunId = 10;
//var urunler = (from urun in context.Urunler
//               where urun.UrunId>urunId
//               select urun);
//urunId = 200; //bu sefer bunu alcak neden peki 10 dan büyükleri almadı? yani DeferantExecution var burada onu anlamak gerekir.
//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}
#region Foreach
//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//};
#region Üstteki sorgunun Method sytax ile yazımı
//int urunId = 10;

//var urunler = context.Urunler
//                     .Where(urun => urun.UrunId > urunId);

//urunId = 200;

//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}

#endregion
#endregion
#region Deffered Execution (Ertelenmiş Çalışma)
//IQueryble çalışmalarında ilgili yazıldığı kodda sorgu execute edilmez. Sorgu çalıştırılmadığı için veriler gelmez. Sorgu ancak verilerin kullanıldığı yerde çalıştırılır.örneğin foreach içinde çalıştırılır. oyüzden foreach içinde çalıştırıldığında urunId 200 olduğu için 200 den büyük olanları getirdi. bu duruma ertelenmiş çalışma denir.
#endregion
#region ToListAsync
#region MehodSyntax
//var urunler = await context.Urunler.ToListAsync(); //ToListAsync ile sorguyu execute ettik ve veriler geldi. 
#endregion
#region Query Syntax
//var urunler2 = await (from urun in context.Urunler
//               select urun).ToListAsync(); //ToListAsync ile sorguyu execute ettik ve veriler geldi.
#endregion
#endregion
#endregion


#region IQueraybla ve IEnumerable Nedir? Basit olarak!
//var urunler3 =await (from urun in context.Urunler
//              select urun).ToListAsync(); //elimşzde şuan ürün yok sadece sorgu var. bu sorguyu çalıştırmak için ne yapmamız lazım? Tolistasync ile çalıştırdık ve veriler geldi. IEnumerable oldu.Artık elimizde veriler var.


#region IQurayble
//Sorguya karşılık gelir
//efcore üzerinden gelen sorgunun execute edilmemiş halidir. yani elimde daha veri yok sadece sorgu var.
#endregion
#region IEnumerable
//Sorgunun çalıştırılıp/execute edilip verilerin in memoriye yüklenmiş halini ifade eder. elimde sorgu yok veriler var.
#endregion

#endregion

#region Çoğul Veri Getiren Sorgulama Fonksiyonları

#region ToListAsync()
//Ürütilen sorguyu execute etmek için kullanılan fonksiyondur. bunu yazana kadar sorgu çalıştırılmaz yani IQuerayble. bu fonksiyon çağırıldığında sorgu çalıştırılır ve veriler memorye yüklenir Yani IEnumerable.
#region MethodSyntax
//var urunler = await context.Urunler.ToListAsync();
#endregion
#region Query Syntax
////1.yöntem
//var urunler2 = await (from urun in context.Urunler
//                      select urun).ToListAsync();
////2.yontem
//var urunler3 =  from urun in context.Urunler
//                     select urun;
//var datas =await urunler3.ToListAsync(); //böylede olur.
#endregion;
#endregion

#region Where
// Oluşturulan sorguya filtreleme eklemek için kullanılır.


#region MethodSyntax

#endregion
#region QuerySyntax
// var urunler = from urun in context.Urunler
//               where urun.UrunId<13 && urun.UrunAdi.StartsWith("Y") //burda ve veya gibi operatörler kullanabiliriz.
//               select urun;
////foreach (var urun in urunler)
////{
////    Console.WriteLine(urun.UrunAdi);
////}
////aşşağısı foreachden farklı birşey breakpoint koydum dataaslara baktık 
//var datas = await urunler.ToListAsync(); //böylede olur.
//Console.WriteLine();
#endregion
#endregion

#region OrderBy
// Sorgu üzerinde sıralama yapmak için kullanılır. herhangi bir sorgu olabilir like sorgusu where sorgusu(ASCENDİNG)

#region MethodSyntax
//var urunler = context.Urunler.Where(x => x.UrunId > 10 && x.UrunAdi.StartsWith("y")).OrderBy(x => x.UrunAdi); //ürün id si 10 dan büyük olanları ürün adına göre sıralar
////foreach (var item in urunler) => tolist yazdım sonuna bi yukardaki sorgunun onun devamı bu aşşağıda çağırdım bundan farklı 
////{
////    Console.WriteLine(item.UrunAdi);
////};
#endregion
#region QuerySyntax
#endregion
//var urunler2 = from urun in context.Urunler
//               where urun.UrunId > 10 && urun.UrunAdi.StartsWith("y")
//               orderby urun.UrunAdi //orderby ascending demek
//               select urun;

//await urunler.ToListAsync();
//await urunler2.ToListAsync();
#endregion
#region ThenBy
//order by üzerinden yapılan sıralama işlmeini farklı kolonlara göre yapabilmek için kullanılır. (ASCENDİNG)
//var urunler = context.Urunler.Where(x => x.UrunId > 10 && x.UrunAdi.StartsWith("y")).OrderBy(x => x.UrunAdi).ThenBy(u=> u.Fiyat); //eğer urun adı aynıysa fiyata göre sırala yani
//await urunler.ToListAsync();

#endregion

#region OrderByDescending
//OrderByın tam tersi olarak kullanılır. (DESCENDING)
#region MethodSyntax
//var urunler = await context.Urunler
//    .Where(x => x.UrunId > 5 && x.UrunAdi.StartsWith("Y"))
//    .OrderByDescending(x => x.UrunAdi).ToListAsync();
////ürün id si 10 dan büyük olanları ürün adına göre sıralar
//Console.WriteLine();//DEBUG çalışsın diye koydum kafan karışmasıns
#endregion
#region QuerySyntax
//var urunler2 =await (from urun in context.Urunler
//               orderby urun.UrunAdi descending //orderby ascending demek
//               select urun).ToListAsync();
#endregion
#endregion

#region ThenByDescending
//OrderByDescending üzerinden yapılan sıralama işlemini farklı kolonlara göre yapabilmek için kullanılır. (DESCENDING)
//var urunler = await context.Urunler.OrderByDescending(x=>x.UrunAdi).ThenByDescending(x=>x.Fiyat).ToListAsync();
//Console.WriteLine();//DEBUG çalışsın diye koydum kafan karışmasıns
#endregion
#endregion


/// <summary>
/// tekil veri aşşağısı
/// </summary>


#region Tekil veri getiren sorgulama fonksiyonları
// yapılan sorgda sadece tek bir verinin gelmesi amaçlanıyorsa Single yada SingleOrDefault kullanılır.
//yapılan sorguda tek bir verinin gelmesi amaçlanıyorsa SingleAsync yada SingleOrDeafultAsync fonk. kullanılabilir. uniqe email varsa birden fazla email tutarsızlık gelirse bunun güvencesini bunla alabilirzi tekil veri eminliği yoksa patlar zaten. çoğul ve gelmiyorsa 
#region SingleAsync
//sorgu neticesinde birden fazla veri geliyorsa yada hiç gelmiyorsa her 2 durumdada exception fırlatır.
#region tek kayıt geldiğinde
//var urun = await context.Urunler.SingleAsync(x=>x.UrunId == 10); //tek kayıt gelirse sıkıntı yok
//Console.WriteLine();
#endregion

#region Hiç Kayıt gelmediğinde
//var urun = await context.Urunler.SingleAsync(x => x.UrunId == 1000); //tek kayıt gelirse sıkıntı yok
//Console.WriteLine();
#endregion

#region Çok Kayıt geldiğinde
//var urun = await context.Urunler.SingleAsync(x => x.UrunId > 10); //burda birden fazla kayıt gelirse exception fırlatır
#endregion
#endregion

#region SingleOrDeafultAsync
//eğerki sorgu neticesinde birden fazla veri gelmiyorsa exception fırlatır. ama hiç kayıt gelmiyorsa null döner.
#region tek kayıt geldiğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(x=>x.UrunId == 10); //tek kayıt gelirse sıkıntı yok
//Console.WriteLine();
#endregion

#region Hiç Kayıt gelmediğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(x => x.UrunId == 1000); //bu sefer SingleAsyncde exception fırlatırdı ama bunda null döner
//Console.WriteLine();
#endregion

#region Çok Kayıt geldiğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(x => x.UrunId > 10); //burda  da birden fazla kayıt gelirse exception fırlatır
//Console.WriteLine();
#endregion
#endregion


// yapılan sorguda tek bir verinin gelmesi amaçlanıyorsa first yada firsordefault fonk. kullanılabilir. tekil elde etmek veriyi ahmet kullancısının bireşyi lazım ama birden fazla ahmet deolabilir ama ben 1 ini istiyorum.
#region FirstAsync
// Sorgu neticesinde verilerden ilkini getirir. eğerki hiç verigelmezse hata fırlatır.
#region tek kayıt geldiğinde
//var urun = await context.Urunler.FirstAsync(x=>x.UrunId == 10); //tek kayıt gelirse sıkıntı yok
#endregion

#region Hiç Kayıt gelmediğinde
//var urun = await context.Urunler.FirstAsync(x => x.UrunId == 1000); //tek kayıtda hata fırlatır.

#endregion

#region Çok Kayıt geldiğinde
//var urun = await context.Urunler.FirstAsync(x => x.UrunId > 100);
//// çok kayıt gelirse ilkini getirir. exception fırlatmaz
#endregion
#endregion

#region FirsOrDefaultAsync
//Sorgu neticesinde elde edilen verilerden ilkini getirir eğerki hiçveri gelmezse default oalarak null değerini döndürür.
#region tek kayıt geldiğinde
//var urun = await context.Urunler.FirstOrDefaultAsync(x => x.UrunId == 10); //tek kayıt gelirse sıkıntı yok 

#endregion

#region Hiç Kayıt gelmediğinde
//var urun = await context.Urunler.FirstOrDefaultAsync(x => x.UrunId == 1000); //bu sefer  bunda null döner

#endregion

#region Çok Kayıt geldiğinde
//var urun = await context.Urunler.FirstOrDefaultAsync(x => x.UrunId > 10); //burda  da birden fazla kayıt gelirse İLKİNİ bizee dönderir yoksa exception fırlatmaz

#endregion
#endregion

#region SingleAsync , SingleOrDefaultAsync , FirstAsync ,FirstOrDeafultAsync fok. karşılaştırılması

#endregion

#region FindAsync => include ile kullanılamaz yad where ile kullanılamaz
// Primary key üzerinden tekil veri getirmek için kullanılır. eğerki birden fazla primary key varsa tüm primary key değerleri parametre olarak verilmelidir. findasync sadece primary key ler için geçerlidir. başka kolonlar için kullanılamaz.
//var urun =await context.Urunler.FindAsync(10); //tek primary key varsa böyle kullanılır
#region Composite Primary key durumu
var urunparca = await context.UrunParcalar.FindAsync(10,1);

//ürünparca tablosunda 2 tane primary key var urunid ve parcaid 10 ve 1 verdik
//composite primary key varsa tüm primary key ler parametre olarak verilir
#endregion
#endregion

#region LastAsync OrderBy ile kullanılır
//first ve firstordefaultun tam tersi olarak çalışır. sorgu neticesinde elde edilen verilerin sonuncusunu getirir. eğerki hiç veri gelmezse hata fırlatır.

//var urun = await context.Urunler.OrderBy(u =>u.UrunAdi).LastAsync(x => x.UrunId >=10); //burda  da birden fazla kayıt gelirse SONUNCUSUNU bizee dönderir yoksa exception fırlatmaz
//Console.WriteLine(urun.UrunAdi);
#endregion

#region LasOrDefaultAsync
//firstordefaultun tam tersi olarak çalışır. sorgu neticesinde elde edilen verilerin sonuncusunu getirir. eğerki hiç veri gelmezse null döner.

//var urun = await context.Urunler.OrderBy(u => u.UrunAdi).LastOrDefaultAsync(x => x.UrunId >= 10); //burda  da birden fazla kayıt gelirse SONUNCUSUNU bizee dönderir yoksa exception fırlatmaz
#endregion
#endregion


#region Diğer Sorgulama Fonksiyonları
#region CountAsync (integer döner)
//oluşturulan sorgunun execute edilmesi sonucunda kaç adet satırının elde edilmesini sayısal olarak bildiren fonksiyondur.
//var adet = (await context.Urunler.ToListAsync()).Count; //burda tolistasync ile verileri aldık sonra count ile saydık maliyetli birşey.
//var adet2 = await context.Urunler.CountAsync(); //böylede olur tolistasync e gerek yok performans odaklı
//var adet3 = await context.Urunler.Where(x => x.UrunId >= 10).CountAsync(); //böylede olur tolistasync e gerek yok
//Console.WriteLine(adet3);
#endregion
#region LongCountAsync
////çok büyük sayıla varsa long cinsinden aynı işlmei yapcaz counttdaki gibi
////var adet4 = await context.Urunler.LongCountAsync();
//var adet4 = await context.Urunler.LongCountAsync(x=>x.Fiyat % 7 ==0); //şartlı sorgu burayda yazılabilir.
#endregion
#region AnyAsync
//// tsqlde-exists gibi çalışır. sorgu neticesinde en az bir kayıt geliyorsa true geliyorsa false döner.
////varmı yokmu true-false (boolean)
//var sonucVarmi = await context.Urunler.AnyAsync(x=>x.Fiyat>0); //tabloda en az 1 kayıt varsa true yoksa false

//if (sonucVarmi)
//{
//    Console.WriteLine("Tabloda en az 1 kayıt var");
//}
//else
//{
//    Console.WriteLine("Tabloda hiç kayıt yok");
//}
////içerisinde a harfi geçen ürün varmı
//var eVarmi= await context.Urunler.Where(x=>x.UrunAdi.Contains("p")).AnyAsync(); //içerisinde e harfi geçen ürün varmı
//Console.WriteLine(eVarmi);
#endregion
#region MaxAsync
//var fiyat = await context.Urunler.MaxAsync(x=> x.Fiyat); //tablodaki en yüksek fiyatı getirir
//Console.WriteLine(fiyat);
#endregion
#region MinAsync
//var fiyat = await context.Urunler.MinAsync(x => x.Fiyat); //tablodaki en min fiyatı getirir
//Console.WriteLine(fiyat);
#endregion
#region Distinct
//sqldeki terkarlı  kayıtlar tekilleştirmek için kullanılır
#endregion
#region AllAsync

#endregion
#region SumAsync

#endregion
#endregion


Console.WriteLine();

public class EticaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Parca> Parcalar { get; set; }
    public DbSet<UrunParca> UrunParcalar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Provider yapılandırılması
        //connection string
        //lazyloadıngle çalışıcak mı çalışmıcak mı???? => tam anla tam anlamadım.
        optionsBuilder.UseSqlServer("Server=SERHAT\\SQLEXPRESS;Database=EticaretDB123;User Id=sa;Password=1234;TrustServerCertificate=True;");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UrunParca>()
            .HasKey(up => new { up.UrunId, up.ParcaId }); //composite key tanımladık
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
    public ICollection<Parca> Parcalar { get; set; }
}
 public class Parca
{
    public int Id { get; set; }
    public string ParcaAdi { get; set; }
  
}
public class UrunParca
{
    public int UrunId { get; set; } 
    public Urun Urun { get; set; }
    public int ParcaId { get; set; }
    public Parca Parca { get; set; }
}