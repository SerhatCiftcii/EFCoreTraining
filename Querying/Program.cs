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