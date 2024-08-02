1)REFERANS DURUMLARI---------------------------------------------
MiniApp1.API , MiniApp2.API ve MiniApp3.API  bağımsız projeler olarak düşün.


CORE > DATA > SERVICE > UdemyAuthServer.API

Shared ise tüm apilere referans veriyor.
Ortak sınıfları burada tanımlayacağız.
----------------------------------------------------------------------------------------------

IdentityUser ile hazır üyelik sistemini entegre ettik.
NuGet tan >
Microsoft.AspNetCore.Identity.EntityFrameworkCore  indirdik.
UdemyAuthServer.Core > Models > AppUser sınıfını IdentityUser sınıfından miras aldık.

----------------------------------------------------------------------------------------------
