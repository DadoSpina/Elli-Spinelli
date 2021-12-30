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
        int[] vett;

        public CElaborazioneDati(DatiCondivisi condi, Client c, CDomanda dom)
        {
            this.condi = condi;
            this.c = c;
            this.dom = dom;
        }

        public void separate()
        {
            string a = condi.getLastDomandeRicevute();
            domanda = a.Split(';');
        }

        public void valutaTipo()
        {
            switch (domanda[0])
            {
                case "r": //richiesta connessione
                    switch (domanda[1])
                    {
                        case "q":
                            if (!condi.connesso)
                            {
                                //c.toCSV("r", "a", "y");
                            }
                            else
                            {
                                //rifiuta la connessione
                                //c.toCSV("r","a","n")
                            }
                            break;
                        case "a":
                            if (domanda[2] == "n")
                            {
                                condi.connesso = true;
                            }

                            break;

                    }
                    break;
                case "c":
                    if (condi.pronto == false) { 
                        condi.pronto = true;
                    }
                    break;
                case "d": //domanda "base"
                    switch (domanda[1])
                    {
                        case "q":
                            dom.setSelezionata(int.Parse(domanda[2]));
                            //invia risposta
                            break;
                        case "a":
                            //riceve la risposta
                            break;

                    }
                    break;
                case "v": //domanda "vincente"
                    switch (domanda[1])
                    {
                        case "q":
                            //elabora una risposta
                            break;
                        case "a":
                            //riceve la risposta
                            break;

                    }
                    break;
                case "h": //eventuali aiuti
                    switch (domanda[1])
                    {
                        case "q":
                            //elabora una risposta
                            break;
                        case "a":
                            //riceve la risposta
                            break;

                    }
                    break;
                case "l": //richiesta disconnessione
                    switch (domanda[1])
                    {
                        case "q":
                            //elabora una risposta
                            break;
                        case "a":
                            //riceve la risposta
                            break;
                    }
                    break;
            }
        }
    }
}
