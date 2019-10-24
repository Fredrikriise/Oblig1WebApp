using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Avgang
    {
        public int id { get; set; }
        [Display(Name = "Første avgang")]
        [Required(ErrorMessage = "Du er nødt til å skrive inn hvilke holdeplass toget vil reise fra!")]
        public string _forsteAvgang { get; set; }
        [Display(Name = "Siste avgang")]
        [Required(ErrorMessage = "Du er nødt til å skrive inn siste avgang!")]
        public string _sisteAvgang { get; set; }
    }

    public class jsAvgang
    {
        public int id { get; set; }
        public string _forsteAvgang { get; set; }
        public string _sisteAvgang { get; set; }
    }
}