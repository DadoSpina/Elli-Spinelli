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
        public WAccetta(DatiCondivisi condi, Client c)
        {
            InitializeComponent();
            this.condi = condi;
            this.c = c;
        }

        private void btnPronto_Click(object sender, RoutedEventArgs e)
        {
            //c.toCSV("c","","")
            btnPronto.Background = new SolidColorBrush(Color.FromArgb(255, 15, 193, 15));

            //Aspetta che il valore condi.pronto = true e poi si chiude
            while (!condi.pronto)
            {
            }
            Close();
        }
    }
}
