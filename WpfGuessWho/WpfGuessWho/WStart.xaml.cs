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
using System.Windows.Shapes;

namespace WpfGuessWho
{
    public partial class WStart : Window
    {
        DatiCondivisi condi;
        Client c;
        public int valueImage { get; set; }
        public Uri sourceOfTheImage { get; set; }
        Random rand = new Random();
        public WStart(DatiCondivisi condi, Client c)
        {
            sourceOfTheImage = new Uri("maleProfilePicture.jpg", UriKind.Relative);
            InitializeComponent();
            valueImage = 1;
            this.condi = condi;
            this.c = c;
        }
        public void closing()
        {
            Dispatcher.Invoke(() =>
            {
                if (txtUtente.Text != "" && txtUtente.Text != null)
                {
                    condi.Utente = txtUtente.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username", "ATTENTION");
                    condi.aCaso = false;
                }
            });
        }
        private void btnPartita_Click(object sender, RoutedEventArgs e)
        {
            if (txtUtente.Text == "" || txtUtente.Text != null)
            {
                MessageBox.Show("Invalid username", "ATTENTION");
            }
            else
            {
                if (condi.connesso == 1)
                {
                    condi.Utente = txtUtente.Text;
                    condi.sourceOfTheImage = sourceOfTheImage;
                    Close();
                }
                else
                {
                    condi.ip = txtIP.Text; /*invia il messaggio di richiesta connessione*/
                    condi.Utente = txtUtente.Text;
                    condi.sourceOfTheImage = sourceOfTheImage;
                    c.toCSV("r", txtUtente.Text);
                    while (condi.connesso == 0)
                    {
                        Thread.Sleep(100);
                    }
                    if (condi.connesso == 1)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("CONNECTION FAILED", "ERROR");
                        condi.connesso = 0;
                        condi.Utente = "";
                        condi.sourceOfTheImage = new Uri("", UriKind.Relative);

                    }

                }
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (sourceOfTheImage == new Uri("maleProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("femaleProfilePicture.jpg", UriKind.Relative);
            }
            else if (sourceOfTheImage == new Uri("femaleProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("dogProfilePicture.jpg", UriKind.Relative);
            }
            else if (sourceOfTheImage == new Uri("dogProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("catProfilePicture.jpg", UriKind.Relative);
            }
            imgProfilePicture.Source = new BitmapImage(sourceOfTheImage);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (sourceOfTheImage == new Uri("catProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("dogProfilePicture.jpg", UriKind.Relative);
            }
            else if (sourceOfTheImage == new Uri("dogProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("femaleProfilePicture.jpg", UriKind.Relative);
            }
            else if (sourceOfTheImage == new Uri("femaleProfilePicture.jpg", UriKind.Relative))
            {
                sourceOfTheImage = new Uri("maleProfilePicture.jpg", UriKind.Relative);
            }
            imgProfilePicture.Source = new BitmapImage(sourceOfTheImage);
        }
    }
}
