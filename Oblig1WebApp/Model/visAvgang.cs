using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class visAvgang
    {
        public int id { get; set; }
        [Display(Name = "Første avgang")]
        [Required(ErrorMessage = "Du er nødt til å skrive inn hvilke holdeplass toget vil reise fra!")]
        public string forsteAvgang { get; set; }
        [Display(Name = "Siste avgang")]
        [Required(ErrorMessage = "Du er nødt til å skrive inn hvilke holdeplass toget vil reise til!")]
        public string sisteAvgang { get; set; }
        [Display(Name = "Reisetid")]
        [Required(ErrorMessage = "Du er nødt til å skrive inn hvor lang tid toget bruker fra første holdeplass til siste holdeplass!")]
        public string reiseTid { get; set; }
        [Required(ErrorMessage = "Du er nødt til å skrive inn hvilke spor toget vil bruke!")]
        [Display(Name = "Spor")]
        public string spor { get; set; }
        [Required(ErrorMessage = "Du er nødt til å skrive inn tognummeret!")]
        [Display(Name = "Tognummer")]
        public string togNummer { get; set; }
        [Display(Name = "Sone")]
        [Required(ErrorMessage = "Du er nødt til å skrive inn hvilke sone toget kjører i!")]
        public int sone { get; set; }
        [Required(ErrorMessage = "Du er nødt til å skrive inn pris for å kjøre med dette toget!")]
        [Display(Name = "Pris")]
        public int pris { get; set; }
    }

    public class alleavgangstid
    {
        public int id { get; set; }
        [Display(Name = "Avgangstid")]
        [Required(ErrorMessage = "Du er nødt til å skrive inn hvilke klokkeslett toget reiser!")]
        public string avgangstid { get; set; }
        [Display(Name = "Avgangstid retur")]
        [Required(ErrorMessage = "Du er nødt til å skrive inn hvilke klokkeslett toget ankommer!")]
        public string avgangstidRetur { get; set; }
    }

    public class jsVisAvgang
    {
        public int id { get; set; }
        public string forsteAvgang { get; set; }
        public string sisteAvgang { get; set; }
        public string reiseTid { get; set; }
        public string spor { get; set; }
        public string togNummer { get; set; }
        public int sone { get; set; }
        public int pris { get; set; }
    }

    public class jsAlleavgangstid
    {
        public int id { get; set; }
        public string avgangstid { get; set; }
        public string avgangstidRetur { get; set; }
    }
}
