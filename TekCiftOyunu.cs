namespace SayiTekCiftOOP;

/// <summary>
/// Kullanıcıdan sayı alır ve N girilene kadar tek/çift sonucunu gösterir.
/// </summary>
public class TekCiftOyunu
{
    private const string CikisKomutu = "N";
    private readonly TextReader _girdi;
    private readonly TextWriter _cikti;

    public TekCiftOyunu(TextReader girdi, TextWriter cikti)
    {
        _girdi = girdi;
        _cikti = cikti;
    }

    public void Baslat()
    {
        while (true)
        {
            _cikti.Write("Sayı girin (çıkmak için N): ");
            string? giris = _girdi.ReadLine()?.Trim();

            if (string.Equals(giris, CikisKomutu, StringComparison.OrdinalIgnoreCase))
            {
                _cikti.WriteLine("Oyun sona erdi.");
                return;
            }

            if (!int.TryParse(giris, out int deger))
            {
                _cikti.WriteLine("Geçersiz giriş. Lütfen bir tam sayı veya N girin.");
                continue;
            }

            var sayi = new Sayi(deger);
            _cikti.WriteLine(sayi.TekCiftBilgisiAl());
        }
    }
}
