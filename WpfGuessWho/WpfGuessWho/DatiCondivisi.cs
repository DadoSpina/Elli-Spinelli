using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    public class DatiCondivisi
    {
        public string IpTemporary { get; set; }
        public bool aCaso { get; set; }
        public int Utility { get; set; }
        public string nomeAvversario { get; set; }
        public string risposta { get; set; }
        public List<string[]> vettRisposte { get; set; }
        public int vinto { get; set; }
        public string tuoPersonaggio { get; set; }
        public int IDtuoPersonaggio { get; set; }
        public string ip { get; set; }
        public int porta { get; set; }
        public List<CPersona> listPersona { get; set; }
        public List<CDomanda> listDomande { get; set; } 
        public List<string> domandeRicevute { get; set; } //lista che verrà usata dal client per capire quale domanda ha ricevuto
        public string Utente { get; set; }
        public int connesso { get; set; }
        public bool pronto { get; set; }
        public bool closeThread { get; set; }
        public Uri sourceOfTheImage { get; set; }
        public int indiceSelezionata { get; set; }
        public bool turno { get; set; }
        public DatiCondivisi()
        {
            Utility = 0;
            vinto = -1;
            listPersona = new List<CPersona>();
            listDomande = new List<CDomanda>();
            domandeRicevute = new List<string>();
            Utente = "";
            connesso = 0;
            pronto = false;
            ip = "localhost";
            IpTemporary = "localhost";
            porta = 666;
            tuoPersonaggio = "";
            closeThread = false;
            aCaso = true;
            turno = true;
        }
        public int[] findDomandaSbagliata(int s)
        {
            int[] vett = new int[25];
            int j = 0;
            switch (s)
            {
                case 1:
                    for(int i=0; i<listPersona.Count; i++)
                    {
                        if (!listPersona[i].occhiali)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (!listPersona[i].barba)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (!listPersona[i].cappello)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (!listPersona[i].baffi || (listPersona[i].baffi && listPersona[i].barba))
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (!listPersona[i].nasoGrande)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (!listPersona[i].guanceRosse)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (!listPersona[i].capelli)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli != "biondo")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 9:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli != "castano")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 10:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli != "nero")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 11:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli != "rosso")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 12:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli != "bianco")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 13:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi != "azzurro")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 14:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi != "marrone")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 15:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi != "verde")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
            }
            return vett;
        }
        public void addDomandaServer(string domanda)
        {
            domandeRicevute.Add(domanda);
        }
        public string getLastDomandeRicevute()
        {
            if (domandeRicevute.Count > 0)
            {
                string a = domandeRicevute[domandeRicevute.Count - 1];
                domandeRicevute.RemoveAt(domandeRicevute.Count - 1);
                return a;
            }
            return "";
        }
        public string y_n()
        {
            switch (listDomande[indiceSelezionata].ID)
            {
                case 1:
                    if (listPersona[IDtuoPersonaggio - 1].occhiali)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 2:
                    if (listPersona[IDtuoPersonaggio - 1].barba)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 3:
                    if (listPersona[IDtuoPersonaggio - 1].cappello)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 4:
                    if (listPersona[IDtuoPersonaggio - 1].baffi)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 5:
                    if (listPersona[IDtuoPersonaggio - 1].nasoGrande)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 6:
                    if (listPersona[IDtuoPersonaggio - 1].guanceRosse)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 7:
                    if (listPersona[IDtuoPersonaggio - 1].capelli)
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 8:
                    if (listPersona[IDtuoPersonaggio - 1].coloreCapelli == "biondo")
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 9:
                    if (listPersona[IDtuoPersonaggio - 1].coloreCapelli == "marrone")
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 10:
                    if (listPersona[IDtuoPersonaggio - 1].coloreCapelli == "nero")
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 11:
                    if (listPersona[IDtuoPersonaggio - 1].coloreCapelli == "rosso")
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 12:
                    if (listPersona[IDtuoPersonaggio - 1].coloreCapelli == "bianco")
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 13:
                    if (listPersona[IDtuoPersonaggio - 1].coloreOcchi == "azzurro")
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 14:
                    if (listPersona[IDtuoPersonaggio - 1].coloreOcchi == "marrone")
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
                case 15:
                    if (listPersona[IDtuoPersonaggio - 1].coloreOcchi == "verde")
                    {
                        return "Y";
                    }
                    else
                    {
                        return "N";
                    }
            }
            return "";
        }
        public int[] findDomandaGiusta(int s)
        {
            int[] vett = new int[25];
            int j = 0;
            switch (s)
            {
                case 1:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].occhiali)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].barba)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].cappello)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].baffi && !listPersona[i].barba)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].nasoGrande)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].guanceRosse)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].capelli)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "biondo")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 9:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "marrone")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 10:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "nero")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 11:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "rosso")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 12:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "bianco")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 13:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi == "azzurro")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 14:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi == "marrone")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 15:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi == "verde")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
            }
            return vett;
        }
    }
}
