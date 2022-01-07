using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfGuessWho
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatiCondivisi dati = new DatiCondivisi();
        ThreadServer th = new ThreadServer();
        Client c = new Client();
        CElaborazioneDati elab;
        int selected = 0;
        int domSelezionata = 0;
        public MainWindow()
        {
            Thread t1 = new Thread(new ThreadStart(th.riceviPacchetto));
            
            InitializeComponent();
            btnBack.Visibility = Visibility.Hidden;
            btnConferma.Visibility = Visibility.Hidden;
            btnForward.Visibility = Visibility.Hidden;
            btnIndovina.Visibility = Visibility.Hidden;
            lblDomanda.Visibility = Visibility.Hidden;
            lblRisposta.Visibility = Visibility.Hidden;
            rectDomanda.Visibility = Visibility.Hidden;
            rectRisposta.Visibility = Visibility.Hidden;
            WStart window = new WStart(dati);
            Hide();
            window.ShowDialog();
            if (dati.Utente == "")
            {
                Close();
                return;
            }
            Show();
            MessageBox.Show("Choose your character");
            imgUser.Source = new BitmapImage(dati.sourceOfTheImage);

            List<CPersona> listaP = new List<CPersona>();
            List<CDomanda> listaD = new List<CDomanda>();

            CFile file = new CFile("filePersone.csv", dati);
            file.toListPersona();

            CDomanda cdomanda = new CDomanda(dati);
            file.setFileName("fileDomande.csv");
            file.toListDomande();
            lblDomanda.Content = dati.listDomande[0].domanda;
            elab = new CElaborazioneDati(dati, c, cdomanda);
            Thread t2 = new Thread(new ThreadStart(elab.valutaTipo));
        }

        private void btnPronto_Click(object sender, RoutedEventArgs e)
        {
            if (selected != 0)
            {
                imgSelezionato.Source = imgSelectedPerson.Source;
                c.toCSV("c", "", "");
                btnPronto.Background = new SolidColorBrush(Color.FromArgb(255, 15, 193, 15));
                

                while (!dati.pronto)
                {
                }

                //change buttons
                imgSelectedPerson.Source = null;
                btnPronto.Visibility = Visibility.Collapsed;
                btnBack.Visibility = Visibility.Visible;
                btnConferma.Visibility = Visibility.Visible;
                btnForward.Visibility = Visibility.Visible;
                btnIndovina.Visibility = Visibility.Visible;
                lblDomanda.Visibility = Visibility.Visible;
                lblRisposta.Visibility = Visibility.Visible;
                rectDomanda.Visibility = Visibility.Visible;
                rectRisposta.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Choose your character");
            }
        }

        private void btnPersona_Click(object sender, RoutedEventArgs e)
        {
            string bottoneSelezionato = (e.Source as Button).Content as String;
            imgSelectedPerson.Source = new BitmapImage(new Uri(bottoneSelezionato + ".jpg", UriKind.Relative));
            selected = int.Parse(bottoneSelezionato);
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (domSelezionata < dati.listDomande.Count - 1)
            {
                domSelezionata++;
                lblDomanda.Content = dati.listDomande[domSelezionata].domanda;
            }
            else
            {
                domSelezionata=0;
                lblDomanda.Content = dati.listDomande[domSelezionata].domanda;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (domSelezionata > 0)
            {
                domSelezionata--;
                lblDomanda.Content = dati.listDomande[domSelezionata].domanda;
            }
            else
            {
                domSelezionata = dati.listDomande.Count - 1;
                lblDomanda.Content = dati.listDomande[domSelezionata].domanda;
            }
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}