using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Betaling
    {
        public int id { get; set; }

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppis")]
        public string etternavn { get; set; }

        [Display(Name = "Epostadresse")]
        [Required(ErrorMessage = "Emailadresse må oppgis")]
        [EmailAddress(ErrorMessage = "Feil epostadresseformat, prøv igjen")]
        public string email { get; set; }

        [Display(Name = "Kortnummer")]
        [Required(ErrorMessage = "Kortnummeret må oppis")]
        [RegularExpression(@"[0-9]{12}", ErrorMessage = "Kortnummer må være 12 siffer, uten mellomrom!")]
        public string kortnummer { get; set; }

        [Display(Name = "Utløpsdato (Måned/år)")]
        [Required(ErrorMessage = "Utløpsdato må oppis")]
        [RegularExpression(@"[0-9]{2}[/][0-9]{2}", ErrorMessage = "Utløpsdato må ha format mm/yy")]
        public string utløpsDato { get; set; }

        [Display(Name = "CVC/CVC2/CVV2")]
        [Required(ErrorMessage = "CVC/CVC2/CVV2 kode må oppis")]
        [RegularExpression(@"[0-9]{3}", ErrorMessage = "CVC/CVC2/CVV2 koden må være 3 siffer")]
        public string CVC { get; set; }

    }
}
