using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1WebApp.Models
{
    public class Avgang
    {
        public int id { get; set; }
        public string forsteAvgang { get; set; }
        public string sisteAvgang { get; set; }
        public string reiseTid { get; set; }
        public string spor { get; set; }
        public string togNummer { get; set; }
    
     }
}