using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErovizioGUI
{
    internal class Dal
    {
        public int ev { get; set; }
        public int sorrend { get; set; }
        public string orszag { get; set; }
        public string nyelv { get; set; }
        public string eloado { get; set; }
        public string eredeti { get; set; }
        public string magyar { get; set; }
        public int helyezes { get; set; }
        public int pontszam { get; set; }

        public Dal(MySqlDataReader olvaso)
        {
            ev = olvaso.GetInt32(0);
            sorrend = olvaso.GetInt32(1);
            orszag = olvaso.GetString(2);
            nyelv = olvaso.GetString(3);
            eloado = olvaso.GetString(4);
            eredeti = olvaso.GetString(5);
            magyar = olvaso.GetString(6);
            helyezes= olvaso.GetInt32(7);
            pontszam = olvaso.GetInt32(8);
        }

        public Dal()
        {

        }

    }
}

