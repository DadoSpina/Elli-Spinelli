using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    public class CDomanda
    {
		private DatiCondivisi dati;
		public int ID { get; set; }
		public string testo { get; set; }
		public string caratteristica { get; set; }
		public string dettaglio { get; set; }
		private int indiceSelezionata;

		public CDomanda(DatiCondivisi dati)
        {
			this.dati = dati;
			ID = 0;
			testo = "";
			caratteristica = "";
			dettaglio = "";
			indiceSelezionata = 0;
        }

		public CDomanda(String riga)
		{
			String[] vett = riga.Split(';');
			ID = int.Parse(vett[0]);
			testo = vett[1];
			caratteristica = vett[2];
            if (vett[3] == "n")
            {
				dettaglio = "";
            }
            else
            {
				dettaglio = vett[3];
            }
		}

		public void setSelezionata(int indiceSelezionata)  //guarda quale domanda è stata selezionata
		{
			this.indiceSelezionata = indiceSelezionata;
		}

		public int[] check()    
		{
			int[] vettIndici;
			vettIndici = dati.findDomandaSbagliata(indiceSelezionata);
			return vettIndici;
		}
	}
}
