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
        //UdpClient peer;
        string ip;
        int porta;
        List<CPersona> listPersona = new List<CPersona>();
        List<CDomanda> listDomande = new List<CDomanda>();
        //lista che verrà usata dal client per capire quale domanda ha ricevuto
        List<string> domandeRicevute = new List<string>();
        public string Utente { get; set; }
        public bool connesso { get; set; }
        public bool pronto { get; set; }
        public Uri sourceOfTheImage { get; set; }
        public DatiCondivisi()
        {

        }

        public void setPeer(string ip, int porta)
        {
            this.ip = ip;
            this.porta = porta;
        }

        public string getIp()
        {
            return ip;
        }

        public int getPorta()
        {
            return porta;
        }

        public void setListaPersona(List<CPersona> list)
        {
            listPersona = list;
        }

        public List<CPersona> getListaPersona()
        {
            return listPersona;
        }

        public void setListaDomande(List<CDomanda> list)
        {
            listDomande = list;
        }

        public List<CDomanda> getListaDomanda()
        {
            return listDomande;
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

        /*public int[] findPersona(String c, String r)
        {
            int[] vett = null;
            int j = 0;
            for (int i=0; i<listPersona.Count; i++)
            {
                switch (c)
                {
                    case "occhiali":
                        if(listPersona[i].occhiali == bool.Parse(r))
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                        break;
                    case "capelli":
                        if (listPersona[i].capelli == bool.Parse(r))
                        {
                            vett[j] = listPersona[i].id;
                        }
                        break;
                    case "barba":
                        if (listPersona[i].barba == bool.Parse(r))
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                        break;
                    case "baffi":
                        if (listPersona[i].baffi == bool.Parse(r))
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                        break;
                    case "nasoGrande":
                        if (listPersona[i].nasoGrande == bool.Parse(r))
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                        break;
                    case "guanceRosse":
                        if (listPersona[i].guanceRosse == bool.Parse(r))
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                        break;
                    case "cappello":
                        if (listPersona[i].cappello == bool.Parse(r))
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                        break;
                    case "coloreCapelli":
                        if (listPersona[i].coloreCapelli == r)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                        break;
                    case "coloreOcchi":
                        if (listPersona[i].coloreCapelli == r)
                        {
                            vett[j] = listPersona[i].id;
                            j++;
                        }
                        break;
                }
            }
            return vett;
        }*/

        //aggiunge alla lista che verrà usata dal client per capire quale domanda ha ricevuto
        public void addDomandaServer(string domanda)
        {
            domandeRicevute.Add(domanda);
        }

        public string getLastDomandeRicevute()
        {
            return domandeRicevute[domandeRicevute.Count - 1];
        }
    }
}
