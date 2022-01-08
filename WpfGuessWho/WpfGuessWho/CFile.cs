using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    class CFile
    {
		private string fileName;
        private DatiCondivisi dati;
		public CFile(string fileName, DatiCondivisi dati)
		{
			this.fileName = fileName;
			this.dati = dati;
		}

		public void setFileName(string fileName)
        {
			this.fileName = fileName;
		}

		public void toListPersona()
		{
			List<CPersona> lista = new List<CPersona>();
			StreamReader FIN = new StreamReader(fileName);
			string riga = "";

			while ((riga = FIN.ReadLine()) != null)
			{
				String[] vett = riga.Split(';');
				CPersona C = new CPersona(int.Parse(vett[0]), vett[1], bool.Parse(vett[2]), bool.Parse(vett[3]), bool.Parse(vett[4]), bool.Parse(vett[5]), bool.Parse(vett[6]), bool.Parse(vett[7]), bool.Parse(vett[8]), vett[9], vett[10]);
				lista.Add(C);
			}
			dati.listPersona = lista;
			FIN.Close();
		}

		public void toListDomande()
		{
			List<CDomanda> lista = new List<CDomanda>();
			StreamReader FIN = new StreamReader(fileName);

			FIN.ReadLine();
			while (!FIN.EndOfStream)
			{
				string riga = FIN.ReadLine();
				CDomanda C = new CDomanda(riga);
				lista.Add(C);
			}
			dati.listDomande = lista;
			FIN.Close();
		}
	}
}
