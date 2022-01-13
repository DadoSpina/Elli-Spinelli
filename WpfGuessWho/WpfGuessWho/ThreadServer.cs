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
        UdpClient server;
        byte[] data;
        IPEndPoint reciveEP;
        DatiCondivisi condi;

        //public ThreadServer()
        //{
        //    server = new UdpClient(666);
        //    data = Encoding.ASCII.GetBytes("");
        //    reciveEP = new IPEndPoint(IPAddress.Any, 666);
        //    condi = new DatiCondivisi();
        //}

        public ThreadServer(DatiCondivisi condi)
        {
            server = new UdpClient(666);
            server.Client.ReceiveTimeout = 1000;
            data = Encoding.ASCII.GetBytes("");
            reciveEP = new IPEndPoint(IPAddress.Any, 666);
            this.condi = condi;
        }


        public void riceviPacchetto()
        {
            while (!condi.closeThread)
            {
                try
                {
                    byte[] dataReceived = server.Receive(ref reciveEP);
                    condi.IpTemporary = reciveEP.Address.ToString();
                    String risposta = Encoding.ASCII.GetString(dataReceived);
                    if (risposta == "")
                    {
                        continue;
                    }
                    condi.addDomandaServer(risposta);
                }
                catch (Exception)
                {
                }
            }
            return;
        }
    }
}
