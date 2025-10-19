# 🗄️ VERİTABANI BAĞLANTI KILAVUZU

## 📌 MEVCUT DURUM

Şu an proje **LocalDB** kullanıyor:
```
Server=(localdb)\mssqllocaldb;Database=RuzgarOtoDB
```

## 🔄 MSSQL'E NASIL GEÇİLİR?

### Yöntem 1: appsettings.json'ı Düzenle (ÖNERİLEN)

**appsettings.json** dosyasını açın ve şu satırı değiştirin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=91.151.90.223;Database=test;User Id=celiltest;Password=d~5yo0P10;TrustServerCertificate=true;MultipleActiveResultSets=true"
  }
}
```

### Yöntem 2: appsettings.Development.json'ı Kullan

**appsettings.Development.json** dosyasında zaten hazır connection string var:

```json
{
  "ConnectionStrings": {
    "ProductionConnection": "Server=91.151.90.223;Database=test;..."
  }
}
```

**Program.cs**'de şu satırı değiştirin:
```csharp
// Eski
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Yeni (Production için)
var connectionString = builder.Configuration.GetConnectionString("ProductionConnection");
```

### Yöntem 3: Ortam Değişkeni ile (Production için en güvenli)

```bash
# Windows PowerShell
$env:ConnectionStrings__DefaultConnection="Server=91.151.90.223;Database=test;..."

# Linux/Mac
export ConnectionStrings__DefaultConnection="Server=91.151.90.223;Database=test;..."
```

## ⚠️ MSSQL'E GEÇERKENİZ YAPMANIZ GEREKENLER

1. **Migration'ı Çalıştırın:**
   ```bash
   dotnet ef database update
   ```

2. **Veritabanının Erişilebilir Olduğundan Emin Olun:**
   - Sunucu çalışıyor mu?
   - Firewall ayarları doğru mu?
   - Kullanıcı adı ve şifre doğru mu?

3. **Bağlantıyı Test Edin:**
   Projeyi çalıştırın ve `/Account/Register` sayfasına gidin.

## 🔐 GÜVENLİK ÖNERİLERİ

### Production'a Çıkarken:

1. **appsettings.json'dan şifreyi kaldırın:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "DEĞER_BURAYA_GELMEMELİ"
     }
   }
   ```

2. **Ortam değişkeni kullanın** (Azure, AWS, Docker)

3. **User Secrets kullanın** (Geliştirme ortamı için):
   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=..."
   ```

4. **Key Vault kullanın** (Azure Key Vault, AWS Secrets Manager)

## 📊 HANGİ VERITABANINI KULLANIYORUM?

Projeyi çalıştırıp loglara bakın:
```
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand ... [ConnectionString=...]
```

---

**Son Güncelleme:** 19 Ekim 2025
**Hazırlayan:** AI Assistant

