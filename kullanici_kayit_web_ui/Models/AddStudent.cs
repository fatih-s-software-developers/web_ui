using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kullanici_kayit_web_ui.Models;

public class AddStudent
{

    [DisplayName("Adı")]
    public string Name { get; set; }

    [DisplayName("Soyadı")]
    public string Surname { get; set; }


    [DataType(DataType.EmailAddress)]
    [DisplayName("Mail Adresi")]
    public string Email { get; set; }
}
