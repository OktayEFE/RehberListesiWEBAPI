# RehberListesiWEBAPI
Rehber Listesi ( .Net Core 6.0 WEB API )
Web Api de bir rehber oluşmu sağlanmaktadır. Rehbere kişi ekleme,silme,güncelleme
ve bu kişilere ait iletişim bilgileri ekleme,silme işlemleri de yapılmaktadır.

Ayrıca Raporlama olarak kişilerin;
Konum Bilgisi
O konumda yer alan rehbere kayıtlı kişi sayısı
O konumda yer alan rehbere kayıtlı telefon numarası sayısı
verileri alınmaktadır.

Yapılan İşlemler ve İsteklerin Yapılma Şekli
- Rehberde Kişi Oluşturma
  url: .../api/Rehber/RehberKaydet
  body: 
        {
          "adi": "Oktay",
          "soyadi": "EFE",
          "firma": "Oktay A.Ş"
        }
   Geri Dönüş:
    Code:200
    Body: Kayıt İşlemi Başarılı
    
    
2- Rehberde Kişi Silme
  url: .../api/Rehber/RehberSil/{id} (.../api/Rehber/RehberSil/1)
  Not: id -> rehberde kayıtlı kişinin rehberID değeri yazılacaktır.
   Geri Dönüş:
    Code:200
    Body: Silme İşlemi Başarılı
 
3- Rehber Kişi Bilgileri Güncelleme
  url: .../api/Rehber/RehberGuncelleme/{id}
  id:8
  body: 
      {
        "adi": "Oktay Yeni",
        "soyadi": "EFE",
        "firma": "Oktay A.Ş"
      }
  Geri Dönüş: Güncelleme İşlemi Başarılı
  
4- Rehberdeki kişiye iletişim bilgisi ekleme
  url: .../api/IletisimBilgileri/IletisimBilgisiKaydet
  body: 
        {
          "iletisimID": 0,
          "telefonNumarasi": "034890046",
          "emailAdresi": "oktayefe56@gmail.com",
          "adres": "Düzce",
          "konum": "Düzce Merkez",
          "rehberID": 1
        }
        Not:iletisimID=0 olarak kalacaktır, rehberID -> kayıtlı bir kişinin rehberID değeri yazılacaktır.
        
        
5- Rehberdeki kişiden iletişim bilgisi kaldırma
  url: .../api/IletisimBilgileri/IletisimBilgisiSilme/{id} (.../api/IletisimBilgileri/IletisimBilgisiSilme/1)
  Not: id -> kayıtlı kişinin iletişim bilgilerinin iletisimID değeridir.
  
  
6- Rehberdeki kişilerin listelenmesi
  url:.../api/Rehber/RehberListesi
  
  
7- Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi
  uurl: .../api/Rehber/KisiBilgileri/{id} (.../api/Rehber/KisiBilgileri/1)
  Not: id -> Rehber de kayıtlı olan kişilerin rehberID değeridir.
  
  
  Raporlama İşlemleri:
  Raprlama da getirilen verileri KAFKA ile Message Queue işlemlerini yapmaya çalıştım.
  Verilerin gönderilme işlemi baarılı fakat veri alma işlemini yapan Consumer projesi veriyi karşılamıyor. 
  
  Unit Test İşlemleri Eklendi.
  Unit test için NUnit projesi oluşturdum. Buu proje ilk defa test yazmaya başladığım projemdir. Test işlemlerini öğrenmeye başladım.
  Öğrendiklerimi bu projede ve bundan sonra ki projelerde uygulayacağım.
  

