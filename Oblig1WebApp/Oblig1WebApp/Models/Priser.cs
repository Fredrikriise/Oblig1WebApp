﻿namespace Oblig1WebApp.Models
{
    public class Priser : Bestilling
    {
        public int voksenBillett = 36;
        public int barneBillett0_5 = 0;
        public int studentBillett = 27;
        public int honnoerBillett = 18;
        public int barneBillett6_17 = 18;
        public int vernepliktigBillett = 18;


        public int totalBillettPris(int voksenBillett, int barneBillett0_5, int studentBillett, int honnørBillett, int barneBillett6_17, int vernepliktigBillett)
        {
            var totalBillettPris = (voksenBillett * voksen) + (barneBillett0_5 * barn0_5) + (studentBillett * student) + (honnoerBillett * honnoer) + (barneBillett6_17 * barn6_17) + (vernepliktigBillett * vernepliktig);
            return totalBillettPris;
        }
    }
}