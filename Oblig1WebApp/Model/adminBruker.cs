using System.ComponentModel.DataAnnotations;

namespace Oblig1WebApp.Models
{

    public class adminBruker
    {
        [Display(Name = "Brukernavn")]
        [Required(ErrorMessage = "Brukernavn må oppgis!")]
        [RegularExpression(@"^[a-zA-Z\d\S]{8,}$", ErrorMessage = "Brukernavn må bestå av minst 8 tegn!")]
        public string brukernavn { get; set; }
        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Passord må oppgis!")]
        [RegularExpression(@"^[a-zA-Z\d\S]{8,}$", ErrorMessage = "Passordet må bestå av minst 8 tegn!")]
        public string passord { get; set; }
    }
}