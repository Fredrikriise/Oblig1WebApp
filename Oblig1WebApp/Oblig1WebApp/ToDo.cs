namespace Oblig1WebApp
{
    public class ToDo
    {                                                                                               /*
    ------ Spørsmål ------
    * VIKTIG * 
    * Enhetstesting - fikse BrukerControllerTest og gjøre AvgangsControllerTest
    * Fikse navbaren (tror kanskje det må lages et nytt prosjekt)

    - Kanskje sette på noen ikoner på kontrollpanel
    - Loggføring til fil, må skrive egen path
    - Verdien til avgangstid og returtid returnerer id'en og ikke verdien
    - Betaling fullført view?

    ----- NOTATER Felix -----
    * Fikse enhetstesting
    * Fikse BrukerControllerTest på registrerBruker (Prøve å teste siste else { })
    * hentAvgang er ikke ordentlig testet
        - slettBetaling vil ikke returne false i stub'en


    ----- Til README-fil ------
    // Enhetstest av BrukerController
    * For testing av BrukerController -> Jeg tester brukernavn og passord i BrukerControllerTest, 
    * .. men i RepositoryStub står det at brukernavn og passord ikke er testet. Så på dette med Anton på torsdag, 
    * .. og han skjønte heller ikke hvorfor det ikke står at det blir testet.


    // Enhetstest for BestillingController
    * Her har jeg testet noen unødvendige ting - trodde jeg skulle teste absolutt alt,
    * .. men Anton fortalte meg på torsdag at vi ikke skulle teste noe fra Oblig1. 
    * .. Dvs. det jeg har testet som er unødvendig er blandt annet hentBestilling og BetalingDetaljer 
    * .. siden dette brukes ved bestilling av togtur.
    * Eneste vi ikke har fått testet her, er om slettBetaling returnerer false. Jeg vet ikke helt hvordan jeg skal teste dette,
    * .. i og med at betaling slettes sammen med bestillingen.
    * Har heller ikke testet regBestilling-metodene, siden dette er en del av oblig1. 
     
    // Enhetstest for AvgangController
    * Her har jeg testet hent-metodene, noe som også er en del av oblig1, dvs. jeg har testet de unødvendig.
    * .. Anton sa det gikk fint å bare la den unødvendige testing være. 


    */
    }
}