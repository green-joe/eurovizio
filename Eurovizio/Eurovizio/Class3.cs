using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eurovizio
{
    class Verseny
    {
        private List<Versenyzo> adatok;
        public Verseny()
        {
            adatok = Versenyzo.LoadFromCsv("eurovizio.csv");
        }
        public double AtlagPont(string orszagNev)
        {
            var orszagVersenyzok = adatok.Where(v => v.orszag == orszagNev).ToList();
            if (orszagVersenyzok.Count == 0)
            {
                return -1;
            }

            var pontszamok = orszagVersenyzok.Select(v => v.pontszam).ToList();
            var atlagPontszam = pontszamok.Average();
            return Math.Round(atlagPontszam, 2);
        }

        public void TopListaKiiras()
        {
            int toplista2000Elott = 0;
            int toplista2000Tol = 0;

            foreach (Versenyzo versenyzo in adatok)
            {
                if (versenyzo.TopLista())
                {
                    if (versenyzo.ev < 2000)
                    {
                        toplista2000Elott++;
                    }
                    else
                    {
                        toplista2000Tol++;
                    }
                }
            }

            Console.WriteLine("2000 előtti toplista versenyzők száma: " + toplista2000Elott);
            Console.WriteLine("2000 utáni toplista versenyzők száma: " + toplista2000Tol);
        }

        public void KiirasElsoHelyezesek()
        {
            var elsoHelyezesek = adatok.Where(v => v.helyezes == 1)
                                        .OrderBy(v => v.ev)
                                        .Select(v => $"{v.ev}: {v.eloado.nev} - {v.cim}");

            foreach (var elsoHelyezes in elsoHelyezesek)
            {
                Console.WriteLine(elsoHelyezes);
            }
        }

        public void LegjobbVersenyzo()
        {
            int maxPontszam = adatok.Max(v => v.pontszam);

            Versenyzo legjobb = adatok.First(v => v.pontszam == maxPontszam);

            Console.WriteLine($"Legmagasabb pontszámot elért versenyző: {legjobb.eloado.nev}, {legjobb.cim}, {legjobb.ev}");
        }

    }
}
