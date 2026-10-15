namespace SayiTekCiftOOP;

/// <summary>
/// Sayıyı private alanda saklar ve kontrollü erişim sağlar.
/// </summary>
public class Sayi
{
    private int _deger;

    public Sayi(int deger)
    {
        SetDeger(deger);
    }

    public int GetDeger()
    {
        return _deger;
    }

    public void SetDeger(int yeniDeger)
    {
        _deger = yeniDeger;
    }

    public bool CiftMi()
    {
        return _deger % 2 == 0;
    }

    public string TekCiftBilgisiAl()
    {
        return CiftMi() ? "Sayı çifttir." : "Sayı tektir.";
    }
}
