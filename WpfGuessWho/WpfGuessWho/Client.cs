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
            riceveEP = new IPEndPoint(IPAddress.Any, 0);
            dati = new DatiCondivisi();
        }

        public Client(DatiCondivisi dati)
        {
            this.dati = dati;
        }

        private void inviaPacchetto(UdpClient client, string s)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(s);
            client.Send(buffer, buffer.Length, dati.getIp(), dati.getPorta());
        }

        /*Public void toCSV(string tipo messaggio, string QoA, string contenuti){
            crea il pacchetto unendo le stringe e richiama inviaPacchetto()
            }*/
    }
}
