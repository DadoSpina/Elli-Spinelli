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
        string[] domanda;
        CDomanda dom;

        public CElaborazioneDati(DatiCondivisi condi, Client c, CDomanda dom)
        {
            this.condi = condi;
            this.c = c;
            this.dom = dom;
        }

        public void valutaTipo()
        {
            string a = condi.getLastDomandeRicevute();
            domanda = a.Split(';');

            switch (domanda[0])
            {
                case "r": //richiesta connessione
                    switch (domanda[1])
                    {
                        default:
                            if (condi.connesso)
                            {
                                c.toCSV("r","N");
                            }
                            else
                            {
                                c.toCSV("r", "Y");
                                condi.connesso = true;
                            }
                            break;
                        case "Y":
                            condi.connesso = true;
                            break;
                        case "N":
                            break;

                    }
                    break;
                case "c": 
                        condi.pronto = true;
                    break;
                default: //domanda "base"
                    switch (domanda[1])
                    {
                        case "q":
                            dom.setSelezionata(int.Parse(domanda[2]));
                            //invia risposta
                            break;
                        case "a":
                            condi.risposta = domanda[2];
                            break;

                    }
                    break;
                case "v": //domanda "vincente"
                    switch (domanda[1])
                    {
                        default:
                            if (domanda[1] == condi.tuoPersonaggio)
                            {
                                c.toCSV("v","Y");
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
                            c.toCSV("d","");
                            break;
                        case "N":
                            condi.vinto = -1;
                            break;
                    }
                    break;
                case "d": //richiesta disconnessione
                    condi.connesso = false;
                    condi.pronto = false;
                    break;
            }
        }
    }
}
