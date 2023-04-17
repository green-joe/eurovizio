using System;
using System.Collections.Generic;
using System.Text;

namespace Eurovizio
{
    class Eloado
    {

        public int eloadoId { get; set; }
        public string nev { get; set; }

        public Eloado(string sor )
        {
            string[] resz = sor.Split(';');
            eloadoId = Convert.ToInt32(resz[0]);
            nev = resz[1];
            
        }
        public Eloado (int eloadoId)
        {
            this.eloadoId = eloadoId;
        }
        public Eloado(int eloadoId, string nev)
        {
            this.eloadoId = eloadoId;
            this.nev = nev;
        }

    }

    

}




    

