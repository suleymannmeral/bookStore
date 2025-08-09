# 📚 Online Kitap Satış Web Uygulaması

Bu proje Acunmedya Akademi ve Akademiq işbirliği ile düzenlenen Senior Developer İbrahim Gökyar tarafından verilen .NET Core developer bootcamp'inin , **Clean Architecture** prensiplerine bağlı kalınarak geliştirilen bir **online kitap satış web uygulamasıdır**. Backend tarafı, **ASP.NET Core Web API** teknolojisi ile yapılandırılmıştır. Kullanıcılar sisteme kayıt olabilir, giriş yapabilir, kitapları görüntüleyebilir, favorilerine ekleyebilir ve sepetlerine kitap ekleyerek alışveriş yapabilirler.

Ayrıca bir **admin paneli** üzerinden, admin yetkisine sahip kullanıcılar kitap ekleyebilir, silebilir ve kullanıcı yönetimi işlemlerini gerçekleştirebilirler.

> 🔧 Proje geliştirme süreci **aktif olarak devam etmektedir**.  
> 🎥 Geliştirme adımlarını takip etmek için: [YouTube Geliştirme Serisi](https://www.youtube.com/watch?v=HA8SWMl7-JE&list=PLowhEyrW96vYQJuMX-0lSa9IC0tuT6Cdg&index=20)

## 🧠 Clean Code Prensipleri

Bu proje geliştirilirken aşağıdaki clean code prensiplerine dikkat edilmeye çalışılmıştır:

- SOLID
- DRY (Don't Repeat Yourself)
- Separation of Concerns
- Katmanlı mimari prensipleri

---

## 🛠 Kullanılan Teknolojiler

| Teknoloji              | Açıklama                                              |
|------------------------|--------------------------------------------------------|
| **ASP.NET Core Web API** | Projenin backend altyapısı                            |
| **MSSQL**              | Veritabanı yönetimi için                              |
| **Entity Framework Core** | ORM aracı olarak                                     |
| **Identity + JWT**     | Kimlik doğrulama ve yetkilendirme işlemleri için      |
| **Postman**            | API testleri ve dokümantasyonu                        |
| **AJAX & Bootstrap**   | UI tarafında dinamiklik ve responsive tasarım için    |

---

## 🔐 Özellikler

### 👤 Kullanıcı İşlemleri
- Kullanıcı kayıt ve giriş
- Kitapları listeleme ve detay görüntüleme
- Kitapları sepete ekleme
- Favori kitaplar listesi

### 🛒 Sepet Sistemi
- Sepete kitap ekleme/çıkarma
- Toplam tutar hesaplama

### 🔐 Admin Paneli
- Kitap ekleme, güncelleme ve silme
- Kullanıcı yönetimi


## 🧱 Katmanlar

Bu projede Clean Architecture yapısı temel alınarak katmanlı bir mimari benimsenmiştir. Her bir katman belirli bir sorumluluğu yerine getirmek üzere yapılandırılmıştır:

| Katman Adı           | Açıklama |
|----------------------|----------|
| **Domain Katmanı**   | (Bu katman, uygulamanın iş kurallarını ve temel varlıklarını içerir. Diğer katmanlara bağımlı değildir.) |
| **Application Katmanı** | (Uygulamanın use case'lerini ve iş akışlarını içerir. Domain katmanına bağımlıdır ama dış katmanlara bağımlı değildir.) |
| **Infrastructure Katmanı** | (Veritabanı işlemleri, dış servislerle iletişim gibi altyapı ile ilgili işlemler burada bulunur.) |
| **Presentation Katmanı**      | (Kullanıcıdan gelen isteklerin alındığı ve dış dünyaya açılan uç noktalardır. Controller yapıları burada bulunur.) |
| **WEBAPI Katmanı**      | (Projenin konfigrasyonu işlemelerini içermektedir.(DI kayıtları, Middlewareler vs....) |


> 🔄 Bu yapı sayesinde, her bir katman birbirinden ayrılmış olur ve bakım, test edilebilirlik ile ölçeklenebilirlik artar.

## 📌 Notlar

- Proje `Clean Architecture` yapısında modüler olarak organize edilmiştir.
- Geliştirme süreci GitHub üzerinden düzenli olarak güncellenmektedir.
- Kod yapısı `Clean Code` prensiplerine uygun olarak yazılmaya özen gösterilmiştir.

---

## 📬 İletişim

Her türlü soru, görüş veya öneriniz için bana GitHub üzerinden ulaşabilirsiniz.

---
