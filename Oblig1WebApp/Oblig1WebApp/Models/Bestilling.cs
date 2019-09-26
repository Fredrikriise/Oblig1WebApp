using System;
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

        [Display(Name = "Bilettype")]
        [Required(ErrorMessage = "Bilettype må oppgis")]
        public string billettType { get; set; }

        [Display(Name = "Dato utreise")]
        [Required(ErrorMessage = "Dato må oppgis")]
        public DateTime? utreiseDato { get; set; }

        [Display(Name = "Klokkeslett utreise")]
        [Required(ErrorMessage = "Tid må oppgis")]
        public string utreiseTid { get; set; }

        [Display(Name = "Dato retur")]
        public DateTime? returDato { get; set; }

        [Display(Name = "Klokkeslett retur")]
        public string returTid { get; set; }

        [Display(Name = "Antall voksenbilletter")]
        public int voksen { get; set; }
        [Display(Name = "Antall barn 0-5 billetter")]
        public int barn0_5 { get; set; }
        [Display(Name = "Antall studentbilletter")]
        public int student { get; set; }
        [Display(Name = "Antall honnørbilletter")]
        public int honnoer { get; set; }
        [Display(Name = "Antall vernepliktbilletter")]
        public int vernepliktig { get; set; }
        [Display(Name = "Antall barn 6-17 billetter")]
        public int barn6_17 { get; set; }

        [Display(Name = "Barnevogn")]
        public bool barnevogn { get; set; }
        [Display(Name = "Sykkel")]
        public bool sykkel { get; set; }
        [Display(Name = "Hund over 40cm")]
        public bool hundover_40cm { get; set; }
        [Display(Name = "Kjæledyr under 40cm")]
        public bool kjaeledyrunder_40cm { get; set; }
    }
}