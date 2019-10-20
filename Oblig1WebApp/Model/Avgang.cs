using System.ComponentModel.DataAnnotations;

namespace Oblig1WebApp.Models
{
    public class Avgang
    {
        public int id { get; set; }
        [Display(Name = "Første avgang")]
        public string _forsteAvgang { get; set; }
        [Display(Name = "Siste avgang")]
        public string _sisteAvgang { get; set; }
    }

    public class jsAvgang
    {
        public int id { get; set; }
        public string _forsteAvgang { get; set; }
        public string _sisteAvgang { get; set; }
    }
}