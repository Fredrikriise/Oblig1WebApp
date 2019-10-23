namespace Oblig1WebApp
{
    public class ToDo
    {                                                                                               /*
    ------ Spørsmål ------
    * VIKTIG * 
    * Enhetstesting - fikse BrukerControllerTest og gjøre AvgangsControllerTest
    * Fikse navbaren (tror kanskje det må lages et nytt prosjekt)

    - Kanskje sette på noen ikoner på kontrollpanel
    - Er det forskjell på å bruke:
     "<input type="submit" value="Tilbake til kontrollpanel" formaction="/Bruker/Kontrollpanel" class="btn btn-primary" />"
     og 
     "<a href="/Bruker/Kontrollpanel"><input type="button" value="Tilbake til kontrollpanel" class="btn btn-primary" /></a>
    - Fiks listBestilling-viewet.
    - Hva skal vi gjøre med betalingsinformasjon? Blir det ikke feil at brukere skal se slik sensitiv informasjon?
    - Vi har ikke satt på required på avgangklassene, og man kan derfor registrere uten å skrive noe. 
    ^ .. Går dette greit siden det er på bruker delen? Litt kjedelig å måtte slette viewsene, generere de på nytt og så endre igjen
    - Loggføring til fil, må skrive egen path

    ----- NOTATER Felix -----
    * Fikse enhetstesting for regBestilling-metodene og AvgangController
    * Fikse BrukerControllerTest på registrerBruker
    
    * Får man testet ViewData med RedirectToRouteResult?
    * Trengs denne kodelinjen? var resultat = (alleavgangstid)actionResult.Model;
    * Er hentBestilling_Feilet riktig testet?
    * Skal "endretAvgang ikke funnet ved view"-test være med?
    * hentBetaling og lagreBetaling, nødvendig?
    */
    }
}