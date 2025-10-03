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
//               select urun).ToListAsync(); //query syntax oldu c# sorgusu
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
    public ICollection<Parca> Parcalar { get; set; }
}
 public class Parca
{
    public int Id { get; set; }
    public string ParcaAdi { get; set; }
}