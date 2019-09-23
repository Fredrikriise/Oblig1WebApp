using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Oblig1WebApp.Models
{
    public class Bestilling
    {
        public int id { get; set; }

        [Display(Name = "Reise fra")]
        [Required(ErrorMessage = "Startsted må oppgis")]
        public string fraLokasjon { get; set; }

        [Display(Name = "Reise til")]
        [Required(ErrorMessage = "Sluttsted må oppgis")]
        public string tilLokasjon { get; set; }

        [Required(ErrorMessage = "Dato må oppgis")]
        public DateTime dato { get; set; }

        [Required(ErrorMessage = "Tid må oppgis")]
        public DateTime tid { get; set; }

        [Required(ErrorMessage = "Bilettype må oppgis")]
        public string bilettType { get; set; }

        [Display(Name = "Reisende")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string reisende { get; set; }

        [Required(ErrorMessage = "Antall reisende må oppgis")]
        public int reisendeAntall { get; set; }

        public bool barnevogn { get; set; }
        public bool sykkel { get; set; }
        public bool hundover_40cm { get; set; }
        public bool kjaeledyrunder_40cm { get; set; }


        [Display(Name = "Kundenummer")]
        public int kundeId { get; set; }


    }
}