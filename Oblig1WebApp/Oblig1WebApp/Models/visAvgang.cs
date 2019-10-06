using System.ComponentModel.DataAnnotations;

namespace Oblig1WebApp.Models
{
    public class visAvgang
    {
        public int id { get; set; }
        [Display(Name = "Første avgang")]
        public string forsteAvgang { get; set; }
        [Display(Name = "Siste avgang")]
        public string sisteAvgang { get; set; }
        [Display(Name = "Reisetid")]
        public string reiseTid { get; set; }
        [Display(Name = "Spor")]
        public string spor { get; set; }
        [Display(Name = "Tognummer")]
        public string togNummer { get; set; }
        [Display(Name = "Sone")]
        public int sone { get; set; }
        [Display(Name = "Pris")]
        public int pris { get; set; }
    }

    public class alleavgangstid
    {
        public int id { get; set; }
        [Display(Name = "Avgangstid")]
        public string avgangstid { get; set; }
        [Display(Name = "Avgangstid retur")]
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
