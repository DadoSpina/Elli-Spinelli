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
			int j = 0;

			while ((riga = FIN.ReadLine()) != null)
			{
				String[] caratteristica = new string[9];
				String[] vett = riga.Split(';');
				String[] campo = vett[2].Split(',');
				for (int i = 0; i < campo.Length; i++)
				{
					String[] s = campo[i].Split('=');
					caratteristica[i] = s[1];
				}
				CPersona C = new CPersona(int.Parse(vett[0]), vett[1], caratteristica[0], caratteristica[1], caratteristica[2], caratteristica[3], caratteristica[4], caratteristica[5], caratteristica[6], caratteristica[7]);
				lista.Add(C);
				j++;
			}
			dati.setListaPersona(lista);
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
			dati.setListaDomande(lista);
			FIN.Close();
		}
	}
}
