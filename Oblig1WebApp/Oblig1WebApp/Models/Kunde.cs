using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Oblig1WebApp.Models
{
    public class Kunde
    {
        public int id { get; set; }
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string fornavn { get; set; }
        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppis")]
        public string etternavn { get; set; }
        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Adresse må oppis")]
        public string adresse { get; set; }
        [Display(Name = "Postnr")]
        [Required(ErrorMessage = "Postnummer må oppis")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnr må være 4 siffer")]
        public string postnr { get; set; }
        [Display(Name = "Poststed")]
        [Required(ErrorMessage = "Poststed må oppis")]
        public string poststed { get; set; }
    }
}