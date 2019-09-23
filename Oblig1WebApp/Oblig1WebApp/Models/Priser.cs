using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1WebApp.Models
{
    public class Priser
    {
        public int voksenBillett = 36;
        public int barneBillett0_5 = 0;
        public int studentBillett = 27;
        public int honnørBillett = 18;
        public int barneBillett6_17 = 18;
        public int vernepliktigBillett = 18;


        public int totalBillettPris(int voksenBillett, int barneBillett0_5, int studentBillett, int honnørBillett, int barneBillett6_17, int vernepliktigBillett)  
        {
            var totalBillettPris = (voksenBillett * 1) + (barneBillett0_5 * 1) + (studentBillett * 1) + (honnørBillett * 1) + (barneBillett6_17 * 1) + (vernepliktigBillett * 1);
            return totalBillettPris;
        }
    }
}