using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bestilling
    {
        public int id { get; set; }
        [Display(Name = "Reise fra")]
        public string fraLokasjon { get; set; }
        [Display(Name = "Reise til")]
        public string tilLokasjon { get; set; }
        [Display(Name = "Bilettype")]
        public string billettType { get; set; }
        [Display(Name = "Dato utreise")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? utreiseDato { get; set; }
        [Display(Name = "Avgangstid")]
        public string avgangstid { get; set; }
        [Display(Name = "Dato retur")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? returDato { get; set; }
        [Display(Name = "Avgangstid retur")]
        public string avgangstidRetur { get; set; }
        [Display(Name = "Antall voksenbilletter")]
        public int? voksen { get; set; }
        [Display(Name = "Antall barn 0-5 billetter")]
        public int? barn0_5 { get; set; }
        [Display(Name = "Antall studentbilletter")]
        public int? student { get; set; }
        [Display(Name = "Antall honnørbilletter")]
        public int? honnoer { get; set; }
        [Display(Name = "Antall vernepliktbilletter")]
        public int? vernepliktig { get; set; }
        [Display(Name = "Antall barn 6-17 billetter")]
        public int? barn6_17 { get; set; }
        [Display(Name = "Barnevogn")]
        public int? barnevogn { get; set; }
        [Display(Name = "Sykkel")]
        public int? sykkel { get; set; }
        [Display(Name = "Hund over 40cm")]
        public int? hundover_40cm { get; set; }
        [Display(Name = "Kjæledyr under 40cm")]
        public int? kjaeledyrunder_40cm { get; set; }
    }
}

