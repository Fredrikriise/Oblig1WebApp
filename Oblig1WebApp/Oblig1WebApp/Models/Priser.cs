namespace Oblig1WebApp.Models
{
    public class Priser : Bestilling
    {
        public int voksenBillett = 36;
        public int barneBillett0_5 = 0;
        public int studentBillett = 27;
        public int honnoerBillett = 18;
        public int barneBillett6_17 = 18;
        public int vernepliktigBillett = 18;

        public int antallVoksene, antallBarn0_5, antallStudenter, antallHonnoerer, antallBarn6_17, antallVernepliktige;


        public int totalBillettPris(int voksenBillett, int barneBillett0_5, int studentBillett, int honnoerBillett, int barneBillett6_17, int vernepliktigBillett)
        {
            var totalBillettPris = (voksenBillett * (antallVoksene = voksen.Value)) + (barneBillett0_5 * (antallBarn0_5 = barn0_5.Value)) + (studentBillett * (antallStudenter = student.Value)) + (honnoerBillett * (antallHonnoerer = honnoer.Value)) + (barneBillett6_17 * (antallBarn6_17 = barn6_17.Value)) + (vernepliktigBillett * (antallVernepliktige = vernepliktig.Value));
            return totalBillettPris;
        }
    }
}