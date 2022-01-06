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

        public CDomanda findDomanda(int s)
        {
            CDomanda C = new CDomanda();
            for(int i=0; i<listDomande.Count; i++)
            {
                if(listDomande[i].indiceDomanda == s)
                {
                    C = listDomande[i];
                }
            }
            return C;
        }

        public int[] findPersona(String c, String r)
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
        }

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
