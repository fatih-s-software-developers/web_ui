using System.ComponentModel.DataAnnotations;

namespace kullanici_kayit_web_ui.Models
{
	public class ZorunlulukTesti
	{

        [Required()]
        public string zorunlu { get; set; }

        public string? zorunluDegil { get; set; }
    }
}
