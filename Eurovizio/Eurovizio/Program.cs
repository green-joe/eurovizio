using System;

namespace Eurovizio
{
    class Program
    {
        static void Main(string[] args)
        {

            Verseny verseny = new Verseny();

            Console.Write("Kérem adja meg az ország nevét: ");
            var orszagNev = Console.ReadLine();

            var atlagPontszam = verseny.AtlagPont(orszagNev);
            if (atlagPontszam == -1)
            {
                Console.WriteLine($"Nincs ilyen ország az adatokban: {orszagNev}");
            }
            else
            {
                Console.WriteLine($"{orszagNev} átlagos pontszáma  : {atlagPontszam:F2}");
            }
           
            verseny.TopListaKiiras();
            verseny.KiirasElsoHelyezesek();
            verseny.LegjobbVersenyzo();
        }
        
        
    }
}
