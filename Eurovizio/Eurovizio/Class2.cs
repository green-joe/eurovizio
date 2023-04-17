using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Eurovizio
{
    class Versenyzo
    {
        public int ev { get; set; }
        public string orszag { get; set; }
        public Eloado eloado { get; set; }
        public string cim { get; set; }
        public int helyezes { get; set; }
        public int pontszam { get; set; }

        public Versenyzo(string sor)
        {
            string[] resz = sor.Split(';');
            ev = Convert.ToInt32(resz[0]);
            orszag = resz[1];
            eloado = new Eloado(Convert.ToInt32(resz[2]));
            cim = resz[3];
            helyezes = Convert.ToInt32(resz[4]);
            pontszam = Convert.ToInt32(resz[5]);
        }
        public static List<Versenyzo> LoadFromCsv(string allomanynev)
        {
            List<Versenyzo> adatok = new List<Versenyzo>();
            foreach (string item in File.ReadAllLines(allomanynev).Skip(1))
            {
                adatok.Add(new Versenyzo(item));
            }
            return adatok;
        }
        public bool TopLista()
        {
            if (ev < 2000)
            {
                return pontszam >= 150;
            }
            else
            {
                return pontszam >= 200;
            }
        }

    }

}
