using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1WebApp.Models
{
    public class adminBruker
    {
        [Display(Name = "Brukernavn")]
        [Required(ErrorMessage = "Brukernavn må oppgis!")]
        public string brukernavn { get; set; }
        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Passord må oppgis!")]
        public string passord { get; set; }
    }
}