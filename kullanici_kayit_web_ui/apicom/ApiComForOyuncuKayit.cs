using kullanici_kayit_web_ui.apicom.apiModels.OyuncuKayit;
using kullanici_kayit_web_ui.Models.OyuncuKayit;
using Newtonsoft.Json;
using System.Text;

namespace kullanici_kayit_web_ui.apicom;

public class ApiComForOyuncuKayit
{
    /*
     API communication class
     */
    string mainapiUrl;


    private string getMainapiUrlFromJson() {
        IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        string portNumber = Configuration.GetSection("apiConnectionUrl:port").Value.ToString();
        string baseurl = Configuration.GetSection("apiConnectionUrl:url").Value.ToString();
        string apikeyword = Configuration.GetSection("apiConnectionUrl:keyword").Value.ToString();
        string resulturl = baseurl + ":"+portNumber +"/"+ apikeyword + "/";
        Console.WriteLine("main api url" + resulturl);
        return resulturl;
    }

    public ApiComForOyuncuKayit()
    {
        ///http://localhost:5290/api/OyuncuKayit/
        mainapiUrl = string.Concat(getMainapiUrlFromJson(), "OyuncuKayit/");

    }

    public OyuncuKayitRequest OyuncuKayitEkleObjectConvertToOyuncuKayitRequest(OyuncuKayitEkle oyuncuKayitEkle)
    {

        OyuncuTemelBilgilerTemelKayitEkleRequest oyuncuTemelBilgiler = new OyuncuTemelBilgilerTemelKayitEkleRequest()
        {
            Adi = oyuncuKayitEkle.Adi,
            Soyadi = oyuncuKayitEkle.Soyadi,
            Ulke = oyuncuKayitEkle.Ulke,
            Il = oyuncuKayitEkle.Il,
            TelefonNumarasi = oyuncuKayitEkle.TelefonNumarasi,
            EpostaAdresi = oyuncuKayitEkle.EpostaAdresi,
            Cinsiyet = oyuncuKayitEkle.Cinsiyet,
            DogumYili = Convert.ToInt32(oyuncuKayitEkle.DogumYili),
            Puan = 0,
            BedenOlcusu = oyuncuKayitEkle.BedenOlcusu,
            OyunSeviye = Convert.ToInt32(oyuncuKayitEkle.OyunSeviye),
            DahaOnceKatildiMi = Convert.ToBoolean(oyuncuKayitEkle.DahaOnceKatildiMi),
            
        };
        MacEsTemelKayitEkleRequest macEs = new MacEsTemelKayitEkleRequest()
        {
            CiftMacTercihi = Convert.ToBoolean(oyuncuKayitEkle.CiftMacTercihi),
            CiftEsAdi = oyuncuKayitEkle.CiftEsAdi,
            KarisikMacTercihi = Convert.ToBoolean(oyuncuKayitEkle.KarisikMacTercihi),
            KarisikEsAdi = oyuncuKayitEkle.KarisikEsAdi
        };
        UcretTemelKayitEkleRequest ucret = new UcretTemelKayitEkleRequest()
        {
            UcretOdemesiYapildiMi = Convert.ToBoolean(oyuncuKayitEkle.KarisikMacTercihi),
            OdemeYapanKisininAdiSoyadi = oyuncuKayitEkle.OdemeYapanKisininAdiSoyadi,
            //tarih buraya kullanıcı sadece tarih seçmesine rağmen saat ve dakika bilgisiyle(00:00 şeklinde) geliyor bunu düzeltmek için işlemler yapılabilir
            //bide biz tarihi backend utc ye çeviriyoruz bunuda düzeltelim
            OdemeYapilmasiPlanlananTarih = Convert.ToDateTime(oyuncuKayitEkle.OdemeYapilmasiPlanlananTarih),
        };
        DahaOnceKatildigiLigUcretTemelKayitEkleRequest dahaOnceKatildigiLig = new DahaOnceKatildigiLigUcretTemelKayitEkleRequest()
        {
            UlusalLiglerdeOynadiMi = Convert.ToBoolean(oyuncuKayitEkle.UlusalLiglerdeOynadiMi),
            LigAdi = oyuncuKayitEkle.LigAdi,
        };

        OyuncuKayitRequest oyuncuKayitRequestforreturn = new OyuncuKayitRequest() 
        { 
            OyuncuTemelBilgiler = oyuncuTemelBilgiler,
            MacEs = macEs,
            Ucret = ucret,
            DahaOnceKatildigiLig = dahaOnceKatildigiLig
        };
        return oyuncuKayitRequestforreturn;
    }


    public async Task<string> kayitEkle(OyuncuKayitRequest oyuncuKayitRequest)
    {
        //http://localhost:5290/api/OyuncuKayit/KayitEkle
        string localApiUrl = string.Concat(mainapiUrl, "KayitEkle");
        await Console.Out.WriteLineAsync("kayit ekle api url : " + localApiUrl);
        HttpClient client = new HttpClient();
        string jsonContent = JsonConvert.SerializeObject(oyuncuKayitRequest);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(localApiUrl, content);
        if (response.IsSuccessStatusCode) {
            //response başarılı
            client.Dispose();
            return "başarılı";
        }
        else
        {
            //response başarısız
            client.Dispose();
            return "başarısız";
        }
    }




}
