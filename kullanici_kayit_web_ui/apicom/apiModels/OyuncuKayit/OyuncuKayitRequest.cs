namespace kullanici_kayit_web_ui.apicom.apiModels.OyuncuKayit;

public class OyuncuKayitRequest
{
    public OyuncuTemelBilgilerTemelKayitEkleRequest OyuncuTemelBilgiler { get; set; }

    public MacEsTemelKayitEkleRequest MacEs { get; set; }
    public UcretTemelKayitEkleRequest Ucret { get; set; }

    public DahaOnceKatildigiLigUcretTemelKayitEkleRequest DahaOnceKatildigiLig { get; set; }



}



public class OyuncuTemelBilgilerTemelKayitEkleRequest
{
    public string Adi { get; set; }

    public string Soyadi { get; set; }

    public string Ulke { get; set; }

    public string Il { get; set; }


    public string TelefonNumarasi { get; set; }

    public string EpostaAdresi { get; set; }

    public string Cinsiyet { get; set; }

    public int DogumYili { get; set; }

    //puan
    public double Puan {  get; set; }


	public string BedenOlcusu { get; set; }

    public int OyunSeviye { get; set; }


    public bool DahaOnceKatildiMi { get; set; }
}

public class MacEsTemelKayitEkleRequest
{

    public bool CiftMacTercihi { get; set; }

    public string CiftEsAdi { get; set; }

    public bool KarisikMacTercihi { get; set; }

    public string KarisikEsAdi { get; set; }

}

public class UcretTemelKayitEkleRequest
{
    public bool UcretOdemesiYapildiMi { get; set; }

    public string OdemeYapanKisininAdiSoyadi { get; set; }


    public DateTime OdemeYapilmasiPlanlananTarih { get; set; }
}

public class DahaOnceKatildigiLigUcretTemelKayitEkleRequest
{
    public bool UlusalLiglerdeOynadiMi { get; set; }

    public string LigAdi { get; set; }
}