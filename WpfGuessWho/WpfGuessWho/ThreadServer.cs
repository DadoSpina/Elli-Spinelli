using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    class ThreadServer
    {
        UdpClient client;
        byte[] data;
        IPEndPoint riceveEP;
        DatiCondivisi condi;

        public ThreadServer()
        {
            client = new UdpClient();
            data = Encoding.ASCII.GetBytes("");
            riceveEP = new IPEndPoint(IPAddress.Any, 0);
            condi = new DatiCondivisi();
        }

        public ThreadServer(DatiCondivisi condi)
        {
            this.condi = condi;
        }

        private string riceviPacchetto()
        {
            byte[] dataReceived = client.Receive(ref riceveEP);
            String risposta = Encoding.ASCII.GetString(dataReceived);
            return risposta;
        }

        public void addToCondi()
        {
            while (true)
            {
                string a = riceviPacchetto();
                condi.addDomandaServer(a);
            }
        }
    }
}
