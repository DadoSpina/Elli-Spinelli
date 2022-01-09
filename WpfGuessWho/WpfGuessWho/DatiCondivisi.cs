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
        public string nomeAvversario { get; set; }
        public string risposta { get; set; }
        public List<string[]> vettRisposte { get; set; }
        public int vinto { get; set; }
        public string tuoPersonaggio { get; set; }
        public string ip { get; set; }
        public int porta { get; set; }
        public List<CPersona> listPersona { get; set; }
        public List<CDomanda> listDomande { get; set; }

        //lista che verrà usata dal client per capire quale domanda ha ricevuto
        public List<string> domandeRicevute { get; set; }
        public string Utente { get; set; }
        public int connesso { get; set; }
        public bool pronto { get; set; }
        public bool closeThread { get; set; }
        public Uri sourceOfTheImage { get; set; }
        public DatiCondivisi()
        {
            vinto = -1;
            listPersona = new List<CPersona>();
            listDomande = new List<CDomanda>();
            domandeRicevute = new List<string>();
            Utente = "";
            connesso = 0;
            pronto = false;
            ip = "192.168.1.2";
            porta = 666;
            tuoPersonaggio = "";
            closeThread = false;
        }
        public int[] findDomanda(int s)
        {
            int[] vett = new int[25];
            int j = 0;
            switch (s)
            {
                case 1:
                    for(int i=0; i<listPersona.Count; i++)
                    {
                        if (listPersona[i].occhiali == true)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].barba == true)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].cappello == true)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].baffi == true && listPersona[i].barba == false)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].nasoGrande == true)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].guanceRosse == true)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].capelli == true)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "biondi")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 9:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "castani")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 10:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "neri")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 11:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "rossi")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 12:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreCapelli == "bianchi")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 13:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi == "azzurri")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 14:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi == "marroni")
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                    }
                    break;
                case 15:
                    for (int i = 0; i < listPersona.Count; i++)
                    {
                        if (listPersona[i].coloreOcchi == "verdi")
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
                return domandeRicevute[domandeRicevute.Count - 1];
            }
            return "";
        }
    }
}
