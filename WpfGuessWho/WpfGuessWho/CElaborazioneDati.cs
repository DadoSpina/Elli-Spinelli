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
        WStart start;
        string temp;

        public CElaborazioneDati(DatiCondivisi condi, Client c, CDomanda dom, WStart start)
        {
            this.condi = condi;
            this.c = c;
            this.dom = dom;
            this.start = start;
            temp = "";
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

                                        MessageBoxResult ris = MessageBox.Show("connettiti con ...", "GUESS WHO", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                        if (ris == MessageBoxResult.Yes)
                                            {
                                                if (condi.aCaso)
                                            {
                                                    condi.connesso = 1;
                                                    c.toCSV("r", "Y");
                                                    //condi.Utente = start.txtUtente.Text;
                                                    start.closing();
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
                                        condi.connesso = 1;
                                    break;
                                case "N":
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
                                        break;
                            }
                            break;
                        case "v": //domanda "vincente"
                            switch (domanda[1])
                            {
                                default:
                                    if (domanda[1] == condi.tuoPersonaggio)
                                    {
                                        c.toCSV("v", "Y");
                                        condi.vinto = -1;
                                    }
                                    else
                                    {
                                        c.toCSV("v", "N");
                                        condi.vinto = 1;
                                        }
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
