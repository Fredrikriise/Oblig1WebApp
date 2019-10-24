using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hjelpeklasse 
    {
        public List<Bestilling>  bestilling { get; set; }
        public List<Betaling> betaling { get; set; }
    }
}
