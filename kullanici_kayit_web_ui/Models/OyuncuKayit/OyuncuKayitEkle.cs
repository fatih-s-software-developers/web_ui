using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kullanici_kayit_web_ui.Models.OyuncuKayit;


//form için
public class OyuncuKayitEkle
{
    //Oyuncu Temel Bilgiler

    [DisplayName("Adınız :")]
	[RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$", ErrorMessage = "Sadece harfler girilebilir.")]
	[Required(ErrorMessage = "{0} alanı gereklidir.")]
    public string Adi { get; set; }


    [DisplayName("Soyadınız:")]
	[RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$", ErrorMessage = "Sadece harfler girilebilir.")]
	[Required(ErrorMessage = "{0} alanı gereklidir.")]
    public string Soyadi { get; set; }

    [DisplayName("Ülke:")]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public string Ulke { get; set; }

    [DisplayName("İl:")]
    public string? Il { get; set; }


    [DisplayName("Telefon numaranız (10 hane)(başında 0 olmadan yazınız):")]
    [MinLength(10,ErrorMessage = "Telefon Numarası 10 haneli olmalıdır")]
    [MaxLength(10, ErrorMessage = "Telefon Numarası 10 haneli olmalıdır")]
	[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Telefon numarası sadece rakamlardan oluşmalıdır.(eğer boşluk kullanarak girdiyseniz boşluksuz girin)")]
	[Required(ErrorMessage = "{0} alanı gereklidir.")]
    public string TelefonNumarasi { get; set; }

    [DisplayName("E posta adresiniz : ")]
    [EmailAddress()]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public string EpostaAdresi { get; set; }


    [DisplayName("Cinsiyetiniz : ")]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public string Cinsiyet { get; set; }


    [DisplayName("Doğum Yılınız:")]
    [Range(1000, 2999, ErrorMessage = "Doğum yılınız 1000 den küçük,2999 dan büyük olamaz")]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public int? DogumYili { get; set; }


    [DisplayName("Beden Ölçünüz:")]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public string BedenOlcusu { get; set; }



    [DisplayName("Oyun Seviyeniz:")]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public int? OyunSeviye { get; set; }



    [DisplayName("Daha Önce Veteran Masa Tenisi Turnuvasına Katıldınız mı ? ")]
	[Required(ErrorMessage = "{0} alanı gereklidir.")]

	public bool? DahaOnceKatildiMi { get; set; }

    //Mac Es

    [DisplayName("Çift(double) Maç Tercihiniz :")]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public bool? CiftMacTercihi { get; set; }

    [DisplayName("Çift(double) Eş Adınız :")]
    public string? CiftEsAdi { get; set; }



    [DisplayName("Karışık(mix) Maç Tercihiniz :")]
	[Required(ErrorMessage = "{0} alanı gereklidir.")]
	public bool? KarisikMacTercihi { get; set; }

    [DisplayName("Karışık(mix) Eş Adınız : ")]
    public string? KarisikEsAdi { get; set; }

    // Ucret

    [DisplayName("Ücret Ödemesi Yapıldı Mı ? ")]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public bool? UcretOdemesiYapildiMi { get; set; }


    [DisplayName("Ödeme Yapan veya yapacak kişinin Adı :")]
	[RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$", ErrorMessage = "Sadece harfler girilebilir.")]
	[Required(ErrorMessage = "{0} alanı gereklidir")]
    public string OdemeYapanKisininAdiSoyadi { get; set; }

    [DisplayName("Ödeme Yaptığınız Tarih.(Eğer Ödeme Yapmamış iseniz Ödemeyi Planladığınız Tarihi Seçiniz) :")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Ödeme Yaptığınız Tarih alanı gereklidir")]
	public DateTime? OdemeYapilmasiPlanlananTarih { get; set; }

    // Daha Once Katildigi Lig

    [DisplayName("Ulusal liglerde Oynadınız Mı ? ")]
    [Required(ErrorMessage = "{0} alanı gereklidir.")]
    public bool? UlusalLiglerdeOynadiMi { get; set; }



    [DisplayName("Ulusal Lig Adı : ")]
    public string? LigAdi { get; set; }

}


