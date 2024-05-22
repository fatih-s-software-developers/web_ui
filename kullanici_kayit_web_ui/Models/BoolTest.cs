using Microsoft.AspNetCore.Mvc.Rendering;

namespace kullanici_kayit_web_ui.Models;

public class BoolTest
{
    public string Name { get; set; }

    public bool secim { get; set; }

    public List<SelectListItem> ListedenSec { get; set; }

    public BoolTest()
    {
        ListedenSec = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "Adana",
                Value = "1"
            },
            new SelectListItem()
            {
                Text = "Adıyaman",
                Value = "02"
            },
            new SelectListItem()
            {
                Text = "Adıyaman",
                Value = "02"
            },
            new SelectListItem()
            {
                Text = "Ankara",
                Value = "06"
            },
            new SelectListItem()
            {
                Text = "İstanbul",
                Value = "34"
            },
        };
    }

}
