﻿using System;
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
        
        int domandeGiàFatte = 0;
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
        WStart window;

        public MainWindow()
        {
            InitializeComponent();
            dati = new DatiCondivisi();
            c = new Client(dati);
            th = new ThreadServer(dati);
            cdomanda = new CDomanda(dati);
            file = new CFile("filePersone.csv", dati);
            file.toListPersona();
            //window.Close();
            elab = new CElaborazioneDati(dati, c, cdomanda, window, this);
            t1 = new Thread(th.riceviPacchetto);
            t2 = new Thread(elab.valutaTipo);
            t1.Start();
            t2.Start();
            GraphicReset();
        }

        public void GraphicReset()
        {
            Dispatcher.Invoke(delegate
            {
                variabile = new int[24];
                window = new WStart(dati, c);
                elab.start = window;



                for (int i = 0; i < 24; i++)
                {
                    variabile[i] = 1;
                }
                domandeGiàFatte = 0;
                dati.turno = false;
                btnBack.Visibility = Visibility.Hidden;
                btnConferma.Visibility = Visibility.Hidden;
                btnForward.Visibility = Visibility.Hidden;
                btnIndovina.Visibility = Visibility.Hidden;
                lblDomanda.Visibility = Visibility.Hidden;
                rectDomanda.Visibility = Visibility.Hidden; 
                btnPronto.Background = new SolidColorBrush(Color.FromArgb(255, 15, 193, 15));
                btnPronto.Visibility = Visibility.Visible;
                dati.IDtuoPersonaggio = 0;
                dati.tuoPersonaggio = "";
                dati.Utente = "";
                file.setFileName("fileDomande.csv");
                file.toListDomande();
                lblDomanda.Content = "Il personaggio avversario " + dati.listDomande[0].testo;
                selected = 0;
                imgSelectedPerson.Source = null;
                domandeGiàFatte++;
                imgSelezionato.Source = null;
                btnPersona1.Visibility = Visibility.Visible;
                img1X.Source = null;
                btnPersona2.Visibility = Visibility.Visible;
                img2X.Source = null;
                btnPersona3.Visibility = Visibility.Visible;
                img3X.Source = null;
                btnPersona4.Visibility = Visibility.Visible;
                img4X.Source = null;
                btnPersona5.Visibility = Visibility.Visible;
                img5X.Source = null;
                btnPersona6.Visibility = Visibility.Visible;
                img6X.Source = null;
                btnPersona7.Visibility = Visibility.Visible;
                img7X.Source = null;
                btnPersona8.Visibility = Visibility.Visible;
                img8X.Source = null;
                btnPersona9.Visibility = Visibility.Visible;
                img9X.Source = null;
                btnPersona10.Visibility = Visibility.Visible;
                img10X.Source = null;
                btnPersona11.Visibility = Visibility.Visible;
                img11X.Source = null;
                btnPersona12.Visibility = Visibility.Visible;
                img12X.Source = null;
                btnPersona13.Visibility = Visibility.Visible;
                img13X.Source = null;
                btnPersona14.Visibility = Visibility.Visible;
                img14X.Source = null;
                btnPersona15.Visibility = Visibility.Visible;
                img15X.Source = null;
                btnPersona16.Visibility = Visibility.Visible;
                img16X.Source = null;
                btnPersona17.Visibility = Visibility.Visible;
                img17X.Source = null;
                btnPersona18.Visibility = Visibility.Visible;
                img18X.Source = null;
                btnPersona19.Visibility = Visibility.Visible;
                img19X.Source = null;
                btnPersona20.Visibility = Visibility.Visible;
                img20X.Source = null;
                btnPersona21.Visibility = Visibility.Visible;
                img21X.Source = null;
                btnPersona22.Visibility = Visibility.Visible;
                img22X.Source = null;
                btnPersona23.Visibility = Visibility.Visible;
                img23X.Source = null;
                btnPersona24.Visibility = Visibility.Visible;
                img24X.Source = null;

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
                MessageBox.Show("Choose your character", "GUESS WHO");
            });
        }
        async Task WaitPronto()
        {
            while (!dati.pronto)
            {
                await Task.Delay(100);
            }
            return;
        }
        async private void btnPronto_Click(object sender, RoutedEventArgs e)
        {
            if (dati.tuoPersonaggio == "")
            {
                if (selected != 0)
                {
                    imgSelezionato.Source = imgSelectedPerson.Source;
                    dati.tuoPersonaggio = dati.listPersona[selected - 1].nome;
                    dati.IDtuoPersonaggio = dati.listPersona[selected - 1].id;
                    c.toCSV("c", dati.Utente);

                    btnPronto.Background = new SolidColorBrush(Color.FromArgb(255, 238, 6, 6));
                    await WaitPronto();

                    //change buttons
                    selected = 0;
                    imgSelectedPerson.Source = null;
                    btnPronto.Visibility = Visibility.Collapsed;
                    btnBack.Visibility = Visibility.Visible;
                    btnConferma.Visibility = Visibility.Visible;
                    btnForward.Visibility = Visibility.Visible;
                    btnIndovina.Visibility = Visibility.Visible;
                    lblDomanda.Visibility = Visibility.Visible;
                    rectDomanda.Visibility = Visibility.Visible;

                }
                else
                {
                    MessageBox.Show("Choose your character", "ATTENTION");
                }
            }
            else
            {
                MessageBox.Show("Sei già in attesa", "ATTENTION");
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
            lblDomanda.Content = "Il personaggio avversario ";
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
            lblDomanda.Content = "Il personaggio avversario ";
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
            if (dati.turno)
            {
                dati.turno = false;
                if (domandeGiàFatte == dati.listDomande.Count)
                {
                    MessageBox.Show("hai terminato le domande", "GUESS WHO");
                }
                else
                {
                    c.toCSV(domSelezionata.ToString(), dati.listDomande[domSelezionata].testo);
                    while (dati.Utility == 0)
                    {
                    }
                    dati.Utility = 0;
                    if (dati.risposta == "Y")
                    {
                        MessageBox.Show("Sì", "GUESS WHO");
                    }
                    else
                    {
                        MessageBox.Show("No", "GUESS WHO");
                    }
                    nascondi();
                    selected = 0;
                    imgSelectedPerson.Source = null;
                    domandeGiàFatte++;
                }
            }
            else
            {
                MessageBox.Show("aspetta il tuo turno", "GUESS WHO");
            }
        }

        private void btnIndovina_Click(object sender, RoutedEventArgs e)
        {
            if (dati.turno)
            {
                if (domandeGiàFatte > 0)
                {
                    if (selected != 0)
                    {
                        c.toCSV("v", dati.listPersona[selected - 1].nome);
                        Thread.Sleep(1000);
                        dati.punteggio = (dati.listDomande.Count + 1) * 100;
                        dati.punteggio -= (domandeGiàFatte * 100);
                        //salva su file di tipo .csv "nome vincitore";"punteggio"
                    }
                    else
                    {
                        MessageBox.Show("select who you want to guess first", "GUESS WHO");
                    }
                }
                else
                {
                    MessageBox.Show("Chiedi almeno 1 domanda prima", "GUESS WHO");
                }
            }
            else
            {
                MessageBox.Show("aspetta il tuo turno", "GUESS WHO");
            }
        }

        private void nascondi()
        {

            int[] vett;
            if (dati.risposta == "Y")
            {
                vett = dati.findDomandaSbagliata(dati.listDomande[domSelezionata].ID);
            }
            else
            {
                vett = dati.findDomandaGiusta(dati.listDomande[domSelezionata].ID);
            }
            foreach (var item in vett)
            {
                switch (item)
                {
                    //se non presente e dati.risposta == "N" allora lo cancella
                    case 1:
                        btnPersona1.Visibility = Visibility.Hidden;
                        img1X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        
                        break;
                    case 2:
                        btnPersona2.Visibility = Visibility.Hidden;
                        img2X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 3:
                        btnPersona3.Visibility = Visibility.Hidden;
                        img3X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 4:
                        btnPersona4.Visibility = Visibility.Hidden;
                        img4X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 5:
                        btnPersona5.Visibility = Visibility.Hidden;
                        img5X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 6:
                        btnPersona6.Visibility = Visibility.Hidden;
                        img6X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 7:
                        btnPersona7.Visibility = Visibility.Hidden;
                        img7X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 8:
                        btnPersona8.Visibility = Visibility.Hidden;
                        img8X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 9:
                        btnPersona9.Visibility = Visibility.Hidden;
                        img9X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 10:
                        btnPersona10.Visibility = Visibility.Hidden;
                        img10X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 11:
                        btnPersona11.Visibility = Visibility.Hidden;
                        img11X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 12:
                        btnPersona12.Visibility = Visibility.Hidden;
                        img12X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 13:
                        btnPersona13.Visibility = Visibility.Hidden;
                        img13X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 14:
                        btnPersona14.Visibility = Visibility.Hidden;
                        img14X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 15:
                        btnPersona15.Visibility = Visibility.Hidden;
                        img15X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 16:
                        btnPersona16.Visibility = Visibility.Hidden;
                        img16X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 17:
                        btnPersona17.Visibility = Visibility.Hidden;
                        img17X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 18:
                        btnPersona18.Visibility = Visibility.Hidden;
                        img18X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 19:
                        btnPersona19.Visibility = Visibility.Hidden;
                        img19X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 20:
                        btnPersona20.Visibility = Visibility.Hidden;
                        img20X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 21:
                        btnPersona21.Visibility = Visibility.Hidden;
                        img21X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 22:
                        btnPersona22.Visibility = Visibility.Hidden;
                        img22X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 23:
                        btnPersona23.Visibility = Visibility.Hidden;
                        img23X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                    case 24:
                        btnPersona24.Visibility = Visibility.Hidden;
                        img24X.Source = new BitmapImage(new Uri("x.png", UriKind.Relative));
                        break;
                }
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dati.closeThread = true;
            c.toCSV("d","") ;
        }

        public void closeWindow()
        {
            Dispatcher.Invoke(delegate
            {
                Close();
            });
        }
    }
}