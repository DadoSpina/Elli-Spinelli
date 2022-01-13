using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGuessWho
{
    class CElaborazioneDati
    {
        DatiCondivisi condi;
        Client c;
        CDomanda dom;
        public WStart start;
        string temp;
        MainWindow window;

        public CElaborazioneDati(DatiCondivisi condi, Client c, CDomanda dom, WStart start, MainWindow window)
        {
            this.condi = condi;
            this.c = c;
            this.dom = dom;
            this.start = start;
            temp = "";
            this.window = window;
        }

        public void valutaTipo()
        {
            while (!condi.closeThread)
            {
                lock (this)
                {
                string a = condi.getLastDomandeRicevute();
                if (a != "" && a != null)
                {
                    string[] domanda = a.Split(';');

                        switch (domanda[0])
                    {
                        case "r": //richiesta connessione
                            switch (domanda[1])
                            {
                                default:
                                        temp = condi.ip;
                                        condi.ip = condi.IpTemporary;
                                        if (condi.connesso == 1)
                                    {
                                        c.toCSV("r", "N");
                                            condi.ip = temp;
                                    }
                                        else
                                    {

                                        MessageBoxResult ris = MessageBox.Show("connettiti con " + domanda[1], "GUESS WHO", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                        if (ris == MessageBoxResult.Yes)
                                            {
                                                if (condi.aCaso)
                                            {
                                                    condi.connesso = 1;
                                                    c.toCSV("r", "Y");
                                                    //start.closing();
                                                    start.Dispatcher.Invoke(delegate {
                                                        condi.Utente = start.txtUtente.Text;
                                                        condi.sourceOfTheImage = start.sourceOfTheImage;
                                                        start.Close();
                                                    });
                                                }
                                            else
                                               {
                                                    c.toCSV("r", "N");
                                                    condi.ip = temp;
                                                    condi.aCaso = true;
                                            }
                                        }
                                        else
                                        {
                                            c.toCSV("r", "N");
                                            condi.ip = temp;
                                        }
                                    }
                                    break;
                                case "Y":
                                        temp = condi.ip;
                                        condi.ip = condi.IpTemporary;
                                        condi.connesso = 1;
                                        start.closing();
                                        break;
                                case "N":
                                        temp = condi.ip;
                                        condi.ip = condi.IpTemporary;
                                        condi.connesso = -1;
                                    break;

                            }
                            break;
                        case "c":
                            condi.pronto = true;
                            condi.nomeAvversario = domanda[1];
                            break;
                        default: //domanda "base"
                            switch (domanda[1])
                            {
                                case "Y":
                                    condi.risposta = "Y";
                                    condi.Utility = 1;
                                    break;
                                case "N":
                                    condi.risposta = "N";
                                    condi.Utility = 1;
                                        break;
                                default:
                                    //dom.setSelezionata(int.Parse(domanda[0]));
                                    condi.indiceSelezionata = int.Parse(domanda[0]);
                                    string risposta = condi.y_n();
                                    int i = 0;
                                        if (risposta == "Y")
                                        {
                                            while (i == 0)
                                            {
                                                MessageBoxResult ris = MessageBox.Show("il tuo personaggio " + domanda[1], "GUESS WHO", MessageBoxButton.YesNo);
                                                if (ris == MessageBoxResult.Yes)
                                                {
                                                    c.toCSV(domanda[1], risposta);
                                                    i = 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("rispondi correttamente!", "GUESS WHO");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            while (i == 0)
                                            {
                                                MessageBoxResult ris = MessageBox.Show("il tuo personaggio " + domanda[1], "GUESS WHO", MessageBoxButton.YesNo);
                                                if (ris == MessageBoxResult.No)
                                                {
                                                    c.toCSV(domanda[1], risposta);
                                                    i = 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("rispondi correttamente!", "GUESS WHO");
                                                }
                                            }
                                        }
                                        condi.turno = true;
                                        break;
                            }
                            break;
                        case "v": //domanda "vincente"
                            switch (domanda[1])
                            {
                                default:
                                    if (domanda[1] == condi.tuoPersonaggio)
                                        {
                                            int i = 0;
                                            while (i == 0)
                                            {
                                                MessageBoxResult ris = MessageBox.Show("il tuo personaggio è" + domanda[1] + "?", "GUESS WHO", MessageBoxButton.YesNo);
                                                if (ris == MessageBoxResult.Yes)
                                                {
                                                    c.toCSV("v", "Y");
                                                    i = 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("rispondi correttamente!", "GUESS WHO");
                                                }
                                            }
                                            window.Dispatcher.Invoke(delegate { MessageBox.Show(window, "hai perso. \nmi spiace ha vinto " + condi.nomeAvversario, "GUESS WHO"); });
                                            condi.vinto = -1;
                                        }
                                    else
                                        {
                                            int i = 0;
                                            while (i == 0)
                                            {
                                                MessageBoxResult ris = MessageBox.Show("il tuo personaggio è" + domanda[1] + "?", "GUESS WHO", MessageBoxButton.YesNo);
                                                if (ris == MessageBoxResult.No)
                                                {
                                                    c.toCSV("v", "N");
                                                    i = 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("rispondi correttamente!", "GUESS WHO");
                                                }
                                            }
                                        window.Dispatcher.Invoke(delegate { MessageBox.Show(window, "HAI VINTO! \n con " + condi.punteggio.ToString() + " punti", "GUESS WHO"); });
                                            condi.vinto = 1;
                                        }
                                        window.GraphicReset();
                                        //deve avviare metodo della main window reset();
                                        break;
                                case "Y":
                                    condi.vinto = 1;
                                    break;
                                case "N":
                                    condi.vinto = -1;
                                    break;
                            }
                            break;
                        case "d": //richiesta disconnessione
                            condi.connesso = 0;
                            condi.pronto = false;

                            break;
                        }
                    }
                }

            }
            return;
        }
    }
}
