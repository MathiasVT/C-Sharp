using System;
using System.Collections.Generic;
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

namespace Prac15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WagenPark wp = new WagenPark();
        Garages g = new Garages();
        ExpertiseBureau eb = new ExpertiseBureau();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonVoegToeAuto_Click(object sender, RoutedEventArgs e)
        {
            string _merk = TextMerkAuto.Text;
            string _nummerplaat = TextNummerplaat.Text;
            Wagen wagen = new Wagen(_nummerplaat, _merk);
            TextMerkAuto.Clear();
            TextNummerplaat.Clear();
            if (wp.SchrijfWagenIn(ref wagen))
            {
                MessageBox.Show("Wagen ingegeschreven");
            }
            else
            {
                MessageBox.Show("Geen nummerplaat, wagen niet ingeschreven");
            }  
        }

        private void ButtonVoegToeGarage_Click(object sender, RoutedEventArgs e)
        {
            if (TextNaamGarage.Text == string.Empty || TextMerkGarage.Text == string.Empty)
            {
                MessageBox.Show("Geen garage toegevoegd, vul vereiste parameters in");
            }
            else
            {
                string _naam = TextNaamGarage.Text;
                string _merk = TextMerkGarage.Text;
                Garage garage = new Garage(_naam, _merk);
                g.AutoGarages.Add(garage);
                TextNaamGarage.Clear();
                TextMerkGarage.Clear();
                MessageBox.Show("Garage toegevoegd");
            }
        }

        private void ButtonOverzicht_Click(object sender, RoutedEventArgs e)
        {
            TextBlockOutput.Text = wp.GeefOverzicht();
        }

        private void ButtonExpertise_Click(object sender, RoutedEventArgs e)
        {
            eb.VoerExpertiseUit(wp.Wagens);
            TextBlockOutput.Text = wp.GeefOverzicht();
        }

        private void ButtonReparatie_Click(object sender, RoutedEventArgs e)
        {
            string _nrplaat = TextNummerplaat.Text;
            Wagen w = wp.ZoekWagen(_nrplaat);
            
            if (w != null)
            {
                Garage gar = g.AutoGarages.FirstOrDefault(x => x.Merk.ToUpper() == w.Merk.ToUpper());
                if (gar != null)
                {
                    string output = "de auto met nummerplaat " + _nrplaat + " is gerepareerd";
                    gar.RepareerWagen(ref w);
                    MessageBox.Show(output);
                }
                else
                {
                    MessageBox.Show("Er werd geen garage gevonden");
                }
            }
            else if(TextNummerplaat.Text == string.Empty)
            {
                MessageBox.Show("Geen nummerplaat ingegeven");
            }
            else
            {
                MessageBox.Show("De wagen met nummerplaat " + _nrplaat + " werd niet gevonden");
            }
            TextNummerplaat.Clear();
        }
    }
}
