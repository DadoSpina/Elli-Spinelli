using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    public class Client
    {
        UdpClient client;
        byte[] data;
        IPEndPoint riceveEP;
        DatiCondivisi dati;

        public Client()
        {
            client = new UdpClient();
            data = Encoding.ASCII.GetBytes("");
            riceveEP = new IPEndPoint(IPAddress.Any, 666);
            dati = new DatiCondivisi();
        }

        public Client(DatiCondivisi dati)
        {
            client = new UdpClient();
            data = Encoding.ASCII.GetBytes("");
            riceveEP = new IPEndPoint(IPAddress.Any, 666);
            this.dati = dati;
        }
        public void toCSV(string tipoMess, string contenuti)
        {
            string messaggio = "";
            if (contenuti != "")
            {
                messaggio = tipoMess + ";" + contenuti;
            }
            else
            {
                messaggio = tipoMess;
            }
            inviaPacchetto(client, messaggio);
        }

        private void inviaPacchetto(UdpClient client, string s)
        {
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                client.Send(buffer, buffer.Length, dati.ip, dati.porta);
        }
    }
}
