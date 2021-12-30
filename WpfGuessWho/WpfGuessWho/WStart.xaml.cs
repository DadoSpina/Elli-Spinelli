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
    /// Logica di interazione per WStart.xaml
    /// </summary>
    public partial class WStart : Window
    {
        DatiCondivisi condi;
        public WStart(DatiCondivisi condi)
        {
            InitializeComponent();
            this.condi = condi;
        }

        private void btnPartita_Click(object sender, RoutedEventArgs e)
        {
            condi.Utente = txtUtente.Text;
            //client.toCSV();
            Close();
        }
    }
}
