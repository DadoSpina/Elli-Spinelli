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
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        DatiCondivisi dati;
        Client c = new Client();
        CElaborazioneDati elab;
        int selected = 0;
        int domSelezionata = 0;
        CFile file;
        CDomanda cdomanda;
        ThreadServer th;
        Thread t1;
        Thread t2;

        public MainWindow()
        {
            dati = new DatiCondivisi();
            file = new CFile("filePersone.csv", dati);
            file.toListPersona();
            th = new ThreadServer(dati);
            cdomanda = new CDomanda(dati);
            elab = new CElaborazioneDati(dati, c, cdomanda);

            t1 = new Thread(th.riceviPacchetto);
            t2 = new Thread(elab.valutaTipo);
            t1.Start();
            t2.Start();

            InitializeComponent();
            btnBack.Visibility = Visibility.Hidden;
            btnConferma.Visibility = Visibility.Hidden;
            btnForward.Visibility = Visibility.Hidden;
            btnIndovina.Visibility = Visibility.Hidden;
            lblDomanda.Visibility = Visibility.Hidden;
            lblRisposta.Visibility = Visibility.Hidden;
            rectDomanda.Visibility = Visibility.Hidden;
            rectRisposta.Visibility = Visibility.Hidden;
            WStart window = new WStart(dati,c);
            Hide();
            window.ShowDialog();
            if (dati.Utente == "")
            {
                dati.closeThread = true;
                Close();
                return;
            }
            Show();
            imgUser.Source = new BitmapImage(dati.sourceOfTheImage);


            file.setFileName("fileDomande.csv");
            file.toListDomande();
            lblDomanda.Content = "il tuo personaggio " + dati.listDomande[0].domanda;
            message("Choose your character", "ATTENTION");
        }

        private void btnPronto_Click(object sender, RoutedEventArgs e)
        {
            if (selected != 0)
            {
                imgSelezionato.Source = imgSelectedPerson.Source;
                dati.tuoPersonaggio = dati.listPersona[selected-1].nome;
                selected = 0;
                c.toCSV("c", dati.Utente);
                btnPronto.Background = new SolidColorBrush(Color.FromArgb(255, 15, 193, 15));

                while (!dati.pronto)
                {
                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    //random di DEBUG da rimuovere appena sia possibile ricevere i messaggi
                    int r = rand.Next(1000);
                    if (r == 1)
                    {
                        dati.pronto = true;
                    }
                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
                message("Choose your character", "ATTENTION");
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
            lblDomanda.Content = "Your Character ";
            if (domSelezionata < dati.listDomande.Count - 1)
            {
                domSelezionata++;
                lblDomanda.Content += dati.listDomande[domSelezionata].domanda;
            }
            else
            {
                domSelezionata=0;
                lblDomanda.Content = dati.listDomande[domSelezionata].domanda;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            lblDomanda.Content = "Your Character ";
            if (domSelezionata > 0)
            {
                domSelezionata--;
                lblDomanda.Content += dati.listDomande[domSelezionata].domanda;
            }
            else
            {
                domSelezionata = dati.listDomande.Count - 1;
                lblDomanda.Content += dati.listDomande[domSelezionata].domanda;
            }
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            c.toCSV(domSelezionata.ToString(),dati.listDomande[domSelezionata].domanda);
            
            if (dati.risposta == "y")
            {
                lblRisposta.Content = "Esatto!";
            }
            else
            {
                lblRisposta.Content = "Sbagliato";
            }
        }

        private void btnIndovina_Click(object sender, RoutedEventArgs e)
        {
            if (selected != 0)
            {
                c.toCSV("v",dati.listPersona[selected-1].nome);
                

                //modificare questo if + "dati.risposta" per adattarsi al nuovo protocollo (la risposta si deve trovare in corrispondenza della lettera v cosicchè il programma sappia sia quella giusta per lui)
                if (dati.risposta == "y")
                {
                    lblRisposta.Content = "HAI VINTO!!";
                    c.toCSV("d","");
                    //calcolo punteggio
                }
                else
                {
                    lblRisposta.Content = "Sbagliato";
                    //calcolo punteggio
                }
            }
            else
            {
                message("select who you want to guess first", "ATTENTION");
            }
        }

        private void message(string content, string name)
        {
            MessageBox.Show(content,name);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dati.closeThread = true;
        }
    }
}