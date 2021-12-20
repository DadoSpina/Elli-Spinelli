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
        public MainWindow()
        {
            InitializeComponent();

            /*Thread t = new Thread(ThreadServer.listen);
            t.Start(c)*/

            DatiCondivisi dati = new DatiCondivisi();
            CPersona p = new CPersona();
            CFile file = new CFile("filePersone.csv");
            file.toListPersona();
            txtBoxProva.Text = p.capelliL + p.capelliC + p.occhi + p.carnagione + p.barba + p.nei + p.occhiali + p.lentiggini;
        }
    }
}
