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

            List<CPersona> listaP = new List<CPersona>();
            List<CDomanda> listaD = new List<CDomanda>();
            DatiCondivisi dati = new DatiCondivisi();

            CFile file = new CFile("filePersone.csv", dati);
            file.toListPersona();

            CDomanda cdomanda = new CDomanda(dati);
            file.setFileName("fileDomande.csv");
            file.toListDomande();

            //listaD = dati.getListaDomanda();
            //listaP = dati.getListaPersona();
            
            //for (int i = 0; i < listaP.Count; i++)
            //{
            //    txtBoxProva.Text = listaP[i].capelliL + listaP[i].capelliC + listaP[i].occhi + listaP[i].carnagione + listaP[i].barba + listaP[i].nei + listaP[i].occhiali + listaP[i].lentiggini;
            //}

            //for (int i = 0; i < listaD.Count; i++)
            //{
            //    txtBoxProva.Text += "\n" + listaP[i].capelliL + listaP[i].capelliC + listaP[i].occhi + listaP[i].carnagione + listaP[i].barba + listaP[i].nei + listaP[i].occhiali + listaP[i].lentiggini;
            //}

        }
    }
}
