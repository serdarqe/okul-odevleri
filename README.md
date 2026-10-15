# Sayı Tek mi Çift mi? (OOP)

## Amaç

Kullanıcıdan tam sayı alan, sayının tek veya çift olduğunu bildiren ve kullanıcı `N` yazana kadar devam eden C# konsol uygulaması.

## OOP ve kapsülleme

- `Sayi` sınıfı sayı değerini `private int _deger` alanında saklar.
- `GetDeger()` değeri okumak, `SetDeger(int)` kontrollü biçimde güncellemek için kullanılır.
- Tek/çift denetimi `Sayi` sınıfının `CiftMi()` ve `TekCiftBilgisiAl()` metotlarındadır.
- `TekCiftOyunu` kullanıcı etkileşimini yönetir; sınıflar sorumluluklarına göre ayrılmıştır.
- `N` ve `n` çıkış komutu olarak kabul edilir. Sayı dışındaki girişlerde program hata vermek yerine yeniden giriş ister.

## Çalıştırma

.NET 8 SDK kurulu bir bilgisayarda bu klasörde:

```bash
dotnet run
```

## Örnek kullanım

```text
Sayı girin (çıkmak için N): 12
Sayı çifttir.
Sayı girin (çıkmak için N): 7
Sayı tektir.
Sayı girin (çıkmak için N): N
Oyun sona erdi.
```

## Git commit mesajı

`feat: tek-cift oyununu kapsüllenmiş OOP yapısına dönüştür`
