using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    class CElaborazioneDati
    {
        DatiCondivisi condi = new DatiCondivisi();
        string[] domanda;

        public CElaborazioneDati(DatiCondivisi condi)
        {
            this.condi = condi;
        }

        public void separate()
        {
            string a = condi.getLastDomandeRicevute();
            domanda = a.Split(';');
        }

        public void valutaTipo()
        {
            int DoA = checkDoA(domanda[1]);
            switch (domanda[0])
            {
                case "r": //richiesta connessione
                    switch (DoA)
                    {
                        case 0:
                            //elabora una risposta
                            break;
                        case 1:
                            //riceve la risposta
                            break;
                        case -1:
                            //messaggio di errore
                            break;

                    }
                    break;
                case "d": //domanda "base"
                    switch (DoA)
                    {
                        case 0:
                            //elabora una risposta
                            break;
                        case 1:
                            //riceve la risposta
                            break;
                        case -1:
                            //messaggio di errore
                            break;

                    }
                    break;
                case "v": //domanda "vincente"
                    switch (DoA)
                    {
                        case 0:
                            //elabora una risposta
                            break;
                        case 1:
                            //riceve la risposta
                            break;
                        case -1:
                            //messaggio di errore
                            break;

                    }
                    break;
                case "h": //eventuali aiuti
                    switch (DoA)
                    {
                        case 0:
                            //elabora una risposta
                            break;
                        case 1:
                            //riceve la risposta
                            break;
                        case -1:
                            //messaggio di errore
                            break;

                    }
                    break;
                case "l": //richiesta disconnessione
                    switch (DoA)
                    {
                        case 0:
                            //elabora una risposta
                            break;
                        case 1:
                            //riceve la risposta
                            break;
                        case -1:
                            //messaggio di errore
                            break;

                    }
                    break;
            }
        }

        private int checkDoA(string DoA)
        {
            if (domanda[1] == "q")
            {
                return 0;
            }
            else if (domanda[1] == "a")
            {
                return 1;
            }
            return -1;
        }
        //
    }
}
