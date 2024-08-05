1)REFERANS DURUMLARI---------------------------------------------
MiniApp1.API , MiniApp2.API ve MiniApp3.API  bağımsız projeler olarak düşün.

CORE > DATA > SERVICE > UdemyAuthServer.API

Shared ise tüm apilere referans veriyor.
Ortak sınıfları burada tanımlayacağız.
----------------------------------------------------------------------------------------------
UdemyAuthServer.Core > Models > AppUser sınıfını IdentityUser sınıfından miras aldık.
IdentityUser ile hazır üyelik sistemini entegre ettik.
NuGet tan >
Microsoft.AspNetCore.Identity.EntityFrameworkCore  indirdik.

----------------------------------------------------------------------------------------------
UdemyAuthServer.Data > AppDbContext te
Identity Üyelik sistemi tabloları ve Özel tablolarımız ile ortak db context oluşturduk .

 > AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>

 IdentityDbContext miras verdik çünkü bu dbcontextin içinde üyelik sistemi hazır geliyor.
 Ek olarak DbSet ile ekstra tablolarıda tanıttık yeni AppDbContext dbcontextimize

 ----------------------------------------------------------------------------------------------
 UdemyAuthServer.Data > AppDbContext te OnModelCreating eventinde entitylere dataannotation vermek yerine ;
 UdemyAuthServer.Data > Configurations altında entity bazlı configuration oluşturduk.

 > ProductConfiguration : IEntityTypeConfiguration<Product>
gibi tüm Tabloların dataannotation larını ayarladık .

Ardından DBContext onmodel crettingte topluca bu ayarları verdik 

  protected override void OnModelCreating(ModelBuilder builder)
 {
     >>>builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
     base.OnModelCreating(builder);
 }

 ----------------------------------------------------------------------------------------------
 UdemyAuthServer.Service e  AutoMapper entegre edelim

 NuGeT> AutoMapper 

  UdemyAuthServer.Service > DtoMapper 
  UdemyAuthServer.Service > ObjectMapper 
  oluşturduk.

  --------------------------------------------

  null durumları vs tüm business kodların hepsini servis katmanında yaz.
  Servisten çıkan data direk clienta gidecek olan datadır.!!!
