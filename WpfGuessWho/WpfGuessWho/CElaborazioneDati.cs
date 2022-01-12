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

        public CElaborazioneDati(DatiCondivisi condi, Client c, CDomanda dom, WStart start)
        {
            this.condi = condi;
            this.c = c;
            this.dom = dom;
            this.start = start;
        }

        public void valutaTipo()
        {
            while (!condi.closeThread)
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
                                    if (condi.connesso == 1)
                                    {
                                        c.toCSV("r", "N");
                                    }
                                    else
                                    {

                                        MessageBoxResult ris = MessageBox.Show("connetti", "connettiti con ...", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                        if (ris == MessageBoxResult.Yes)
                                        {
                                            if (condi.aCaso)
                                            {
                                                c.toCSV("r", "Y");
                                                condi.connesso = 1;
                                                //condi.Utente = start.txtUtente.Text;
                                                start.closing();
                                            }
                                            else
                                            {
                                                c.toCSV("r", "N");
                                                condi.aCaso = true;
                                            }
                                        }
                                        else
                                        {
                                            c.toCSV("r", "N");
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
                                    c.toCSV(domanda[1], risposta);
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
                                        condi.vinto = 0;
                                        c.toCSV("d", "");
                                    }
                                    else
                                    {
                                        c.toCSV("v", "N");
                                    }
                                    break;
                                case "Y":
                                    condi.vinto = 1;
                                    c.toCSV("d", "");
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

            return;
        }
    }
}
