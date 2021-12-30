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
        public MainWindow()
        {
            Thread t = new Thread(new ThreadStart(th.addToCondi));

            InitializeComponent();
            WStart window = new WStart(dati);
            WAccetta window2 = new WAccetta(dati);
            Hide();
            window.ShowDialog();
            window2.ShowDialog();
            Show();


            List<CPersona> listaP = new List<CPersona>();
            List<CDomanda> listaD = new List<CDomanda>();

            CFile file = new CFile("filePersone.csv", dati);
            file.toListPersona();

            CDomanda cdomanda = new CDomanda(dati);
            file.setFileName("fileDomande.csv");
            file.toListDomande();
        }
    }
}
