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
            client.Client.Bind(new IPEndPoint(IPAddress.Any, 11000));
            condi = new DatiCondivisi();
        }

        public ThreadServer(DatiCondivisi condi)
        {
            this.condi = condi;
        }


        public void riceviPacchetto()
        {
            while (true)
            {
                byte[] dataReceived = client.Receive(ref riceveEP);
                String risposta = Encoding.ASCII.GetString(dataReceived);
                condi.addDomandaServer(risposta);
            }
        }
    }
}
