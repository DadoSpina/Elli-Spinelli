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
        int[] variabile;

        public MainWindow()
        {
            variabile = new int[24];
            for (int i = 0; i < 24; i++)
            {
                variabile[i] = 1;
            }
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
            lblDomanda.Content = "il tuo personaggio " + dati.listDomande[0].testo;
            message("Choose your character", "ATTENTION");
        }

        private void btnPronto_Click(object sender, RoutedEventArgs e)
        {
            if (selected != 0)
            {
                imgSelezionato.Source = imgSelectedPerson.Source;
                dati.tuoPersonaggio = dati.listPersona[selected - 1].nome;
                dati.IDtuoPersonaggio = dati.listPersona[selected - 1].id;
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
            lblDomanda.Content = "Il tuo personaggio ";
            if (domSelezionata < dati.listDomande.Count - 1)
            {
                domSelezionata++;
                lblDomanda.Content += dati.listDomande[domSelezionata].testo;
            }
            else
            {
                domSelezionata=0;
                lblDomanda.Content += dati.listDomande[domSelezionata].testo;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            lblDomanda.Content = "Il tuo personaggio ";
            if (domSelezionata > 0)
            {
                domSelezionata--;
                lblDomanda.Content += dati.listDomande[domSelezionata].testo;
            }
            else
            {
                domSelezionata = dati.listDomande.Count - 1;
                lblDomanda.Content += dati.listDomande[domSelezionata].testo;
            }
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            c.toCSV(domSelezionata.ToString(),dati.listDomande[domSelezionata].testo);
            while (dati.Utility == 0)
            {
            }
            dati.Utility = 0;
            if (dati.risposta == "Y")
            {
                lblRisposta.Content = "Esatto!";
                nascondi();
            }
            else
            {
                lblRisposta.Content = "Sbagliato";
                nascondi();
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

        private void nascondi()
        {
                switch (/*sistemare il metodo prima*/)
                {
                    //se non presente e dati.risposta == "N" allora lo cancella
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16:
                        break;
                    case 17:
                        break;
                    case 18:
                        break;
                    case 19:
                        break;
                    case 20:
                        break;
                    case 21:
                        break;
                    case 22:
                        break;
                    case 23:
                        break;
                    case 24:
                        break;
                }
            
        }
    }
}