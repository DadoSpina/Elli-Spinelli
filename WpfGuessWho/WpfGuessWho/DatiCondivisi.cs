using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    class DatiCondivisi
    {
        UdpClient peer;
        List<CPersona> listPersona = new List<CPersona>();
        List<CDomanda> listDomande = new List<CDomanda>();

        public DatiCondivisi()
        {

        }

        public void setPeer(string ip, int porta)
        {
            peer = new UdpClient(ip, porta);
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

        public CDomanda findDomanda(String s)
        {
            CDomanda C = new CDomanda();
            for(int i=0; i<listDomande.Count; i++)
            {
                if(listDomande[i].domanda == s)
                {
                    C = listDomande[i];
                }
            }
            return C;
        }

        public int[] findPersona(String c, String r)
        {
            int[] vett = null;
            int j = -1;
            int caratteristica = findCaratteristica(c);
            for (int i=0; i<listPersona.Count; i++)
            {
                if (listPersona[i].vetCaratteristiche[caratteristica] == r) //controllo se persona ha le stesse caratteristiche della domanda fatta se si metto in un vett indice persona per poi la grafica abbassare tale persona
                {
                    vett[j++] = i;
                }
            }
            return vett;
        }

        public int findCaratteristica(String s)
        {
            int caratteristica = 0;
            CPersona p = new CPersona();
            for (int i=0; i<p.vetCaratteristiche.Length; i++)
            {
                if(p.vetCaratteristiche[i] == s)
                {
                    caratteristica = i;
                }
            }
            return caratteristica;
        }
    }
}
