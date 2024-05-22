using kullanici_kayit_web_ui.apicom;
using kullanici_kayit_web_ui.apicom.apiModels.OyuncuKayit;
using kullanici_kayit_web_ui.Models.OyuncuKayit;

using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace kullanici_kayit_web_ui.Controllers
{
    public class OyuncuKayitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OyuncuKayit()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OyuncuKayit(OyuncuKayitEkle oyuncuKayit)
        {
            Console.WriteLine("post controllera gelindi");
            if (ModelState.IsValid)
            {
                //validasyon başarılı
                Console.WriteLine("validasyon başarılı");
                Console.WriteLine("obje düzenlenmeden önce");
                YeniKayitBas(oyuncuKayit);
                /*
                oyuncu kayıt nesnesini düzeltme 
                ( 
                ülkeyi türkiye seçmeyip bir şekilde il seçmeyi başaranlar,
                eş(karışık,çift) istemediği halde eş ismi girenler,
                ulusal ligde oynamadığı halde lig girenler
                )
             */
                string il = (oyuncuKayit.Ulke != "Türkiye") ? "" : oyuncuKayit.Il;
                string ciftEsAdi = (Convert.ToBoolean(oyuncuKayit.CiftMacTercihi)) ? oyuncuKayit.CiftEsAdi : "";
                string karisikEsAdi = (Convert.ToBoolean(oyuncuKayit.KarisikMacTercihi)) ? oyuncuKayit.KarisikEsAdi : "";
                string ulusalLigAdi = (Convert.ToBoolean(oyuncuKayit.UlusalLiglerdeOynadiMi)) ? oyuncuKayit.LigAdi : "";
                oyuncuKayit.Il = il;

                oyuncuKayit.CiftEsAdi = ciftEsAdi;


                oyuncuKayit.KarisikEsAdi = karisikEsAdi;

                oyuncuKayit.LigAdi = ulusalLigAdi;
                Console.WriteLine("obje düzenlendikten sonra");
                YeniKayitBas(oyuncuKayit);

                //api işlemleri
                Console.WriteLine("api isteği başladı");
                ApiComForOyuncuKayit apiComForOyuncuKayit = new ApiComForOyuncuKayit();
                //kullanıcıdan aldığımız oyuncuKayit objesini Api isteği için OyuncuKayitRequest objesine dönüştürüyoruz(mapping)
                OyuncuKayitRequest oyuncuKayitRequest =  apiComForOyuncuKayit.OyuncuKayitEkleObjectConvertToOyuncuKayitRequest(oyuncuKayit);
                //api iletişim class ı iletşim kurup apiye post isteğini gönderiyoruz
                string durum = await apiComForOyuncuKayit.kayitEkle(oyuncuKayitRequest);
                Console.WriteLine("api isteği bitti");
                if (durum == "başarılı")
                {
                    //apiye gönderilen istek başarılı
                    return RedirectToAction("OyuncuKayitDetay", oyuncuKayit);
                }
                else
                {
                    //apiye gönderilen istek başarısız
                    return RedirectToAction("BasarisizIslem",new {mesaj = "Başarısız Api İsteği",yorum = "Apiye atılan istek başarıszıkla sonuçlandı"});
                }


            }
            else
            {
                //validasyon başarısız
                Console.WriteLine("validasyon başarısız");
                return View();
            }
        }

        public IActionResult YeniKayitBas(OyuncuKayitEkle oyuncuKayit)
        {

            Console.WriteLine("==============Yeni kayıt==============");
            Type type = typeof(OyuncuKayitEkle);
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(oyuncuKayit);
                Console.WriteLine(property.Name + ": " + value);
            }

            return NotFound();

        }

        public IActionResult OyuncuKayitDetay(OyuncuKayitEkle oyuncuKayit)
        {
            

            return View(oyuncuKayit);
        }

        public IActionResult BasarisizIslem(string mesaj,string yorum)
        {
            //başarısız bir işlem olmuş
            ViewBag.mesaj = mesaj;
            ViewBag.yorum = yorum;
            return View();
        }

    }
}
