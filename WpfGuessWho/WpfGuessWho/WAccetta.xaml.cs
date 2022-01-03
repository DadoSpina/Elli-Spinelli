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
using System.Windows.Shapes;

namespace WpfGuessWho
{
    /// <summary>
    /// Logica di interazione per WAccetta.xaml
    /// </summary>
    public partial class WAccetta : Window
    {
        DatiCondivisi condi;
        Client c;
        Random rand = new Random();
        public WAccetta(DatiCondivisi condi, Client c)
        {
            InitializeComponent();
            this.condi = condi;
            this.c = c;
        }

        private void btnPronto_Click(object sender, RoutedEventArgs e)
        {
            //c.toCSV("c","","")
            btnPronto.Background = new SolidColorBrush(Color.FromArgb(255, 15, 193, 15)); /*per qualche motivo non cambia colore al bottone ma il resto funziona (immagino sia perchè le modifiche grafice le faccia a fine esecuzione di conseguenza rimanendo bloccato nel while non arriva a eseguire questo comando*/
            
            //Aspetta che il valore condi.pronto = true e poi si chiude
            while (!condi.pronto)
            {
                //genera numero casuale di prova per testare while fino a implementazione metodo "c.toCSV("c","","")", dovrà poi essere eliminato
                int n = rand.Next(100000000);
                if (n == 1)
                {
                    condi.pronto = true;
                }
            }
            Close();
        }

        private void imgUser_Loaded(object sender, RoutedEventArgs e)
        {
            imgUser.Source = new BitmapImage(condi.sourceOfTheImage);
            //lblUserName.Content = "Benvenuto/a " + condi.Utente + "!";
        }
    }
}
