using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    class CElaborazioneDati
    {
        DatiCondivisi condi;
        Client c;
        CDomanda dom;

        public CElaborazioneDati(DatiCondivisi condi, Client c, CDomanda dom)
        {
            this.condi = condi;
            this.c = c;
            this.dom = dom;
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
                                        c.toCSV("r", "Y");
                                        condi.connesso = 1;
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
