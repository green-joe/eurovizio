using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;



namespace ErovizioGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string kapcsolatSzoveg = "datasource=127.0.0.1;port=3306;username=root;password=1234;database=eurovizio;";
        private MySqlConnection kapcsolat;
        private List<Dal> dalok;


        public MainWindow()
        {
            InitializeComponent();
            kapcsolat = new MySqlConnection(kapcsolatSzoveg);

        }

        private Dal dalPont;
        private string eloado;
        private void datagridDal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (datagridDal.SelectedItem != null)
            {
                
                int pontszam = 0;
                int helyezes = 0;
                dalPont = (Dal)datagridDal.SelectedItem;
                eloado=dalPont.eloado;
                kapcsolat = new MySqlConnection(kapcsolatSzoveg);
                kapcsolat.Open();
                string lekerdezoSzoveg = $"SELECT helyezes, pontszam FROM dal where eloado='{eloado}' ";
                MySqlCommand lekerdez = new MySqlCommand(lekerdezoSzoveg, kapcsolat);

                lekerdez.CommandTimeout = 60;
                try
                {
                    MySqlDataReader olvaso = lekerdez.ExecuteReader();

                    if (olvaso.HasRows)
                    {
                        while (olvaso.Read())
                        {
                            pontszam = olvaso.GetInt32("pontszam");
                            helyezes = olvaso.GetInt32("helyezes");                     

                        }
                    }
                    olvaso.Close();
                }
                catch (Exception hiba)
                {
                    MessageBox.Show(hiba.Message);
                }

                labelHelyezes.Content = $"{helyezes}. helyezett";              
                labelPontszam.Content = $"{pontszam} pont";
            }  
            
             kapcsolat.Close();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                        
            int ev = dalPont.ev;            
            kapcsolat = new MySqlConnection(kapcsolatSzoveg);
            kapcsolat.Open();
            string lekerdezoSzoveg = $"SELECT AVG(pontszam) AS atlag FROM dal WHERE ev = " + ev.ToString() ;
            MySqlCommand lekerdez = new MySqlCommand(lekerdezoSzoveg, kapcsolat);
            object result = lekerdez.ExecuteScalar();
            double atlagPontszam = Convert.ToDouble(result);
            lekerdez.CommandTimeout = 60;      

            
            AtlagPontszamLabel.Content = string.Format("{0:F2}", atlagPontszam);
        }

        private void datagridDal_Loaded(object sender, RoutedEventArgs e)
        {

            dalok = new List<Dal>();
            kapcsolat = new MySqlConnection(kapcsolatSzoveg);
            kapcsolat.Open();
            string lekerdezoSzoveg = "SELECT ev, eloado, eredeti FROM dal ORDER BY ev ";
            MySqlCommand lekerdez = new MySqlCommand(lekerdezoSzoveg, kapcsolat);

            lekerdez.CommandTimeout = 60;

            try
            {
                MySqlDataReader olvaso = lekerdez.ExecuteReader();

                if (olvaso.HasRows)
                {
                    while (olvaso.Read())
                    {

                        Dal dal = new Dal
                        {
                            ev = olvaso.GetInt32("ev"),
                            eloado = olvaso.GetString("eloado"),
                            eredeti = olvaso.GetString("eredeti")                           

                        };
                      
                        dalok.Add(dal);                        
                    }
                }
                olvaso.Close();
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
            finally
            {              

                datagridDal.ItemsSource = dalok;
               datagridDal.SelectionChanged += datagridDal_SelectionChanged;

            }
            kapcsolat.Close();

        }         
        
    }  
   
}
    

