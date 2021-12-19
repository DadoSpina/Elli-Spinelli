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
		public CFile(string fileName)
		{
			this.fileName = fileName;
		}

		public void setFileName(string fileName)
        {
			this.fileName = fileName;
		}

		public void toListPersona()
		{
			List<CPersona> lista = new List<CPersona>();
			StreamReader FIN = new StreamReader(fileName);

			FIN.ReadLine();
			while (!FIN.EndOfStream)
			{
				string riga = FIN.ReadLine();
				CPersona C = new CPersona(riga);
				lista.Add(C);
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
