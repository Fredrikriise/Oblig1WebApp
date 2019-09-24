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

        [Required(ErrorMessage = "Bilettype må oppgis")]
        public string bilettType { get; set; }

        [Required(ErrorMessage = "Dato må oppgis")]
        public DateTime utreiseDato { get; set; }

        [Required(ErrorMessage = "Tid må oppgis")]
        public DateTime utreiseTid { get; set; }

        public DateTime returDato { get; set; }

        public DateTime returTid { get; set; }

        [Display(Name = "Reisende")]
        public int voksen { get; set; }
        public int barn0_5 { get; set; }
        public int student { get; set; }
        public int honnør { get; set; }
        public int vernepliktig { get; set; }
        public int barn6_17 { get; set; }

        public bool barnevogn { get; set; }
        public bool sykkel { get; set; }
        public bool hundover_40cm { get; set; }
        public bool kjaeledyrunder_40cm { get; set; }

        [Display(Name = "Kundenummer")]
        public int kundeId { get; set; }


    }
}