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
        List<CPersona> listPersona;

        public void setPeer(string ip, int porta)
        {
            peer = new UdpClient(ip, porta);
        }

        public void setListaPersona(List<CPersona> list)
        {
            listPersona = list;
        }
    }
}
