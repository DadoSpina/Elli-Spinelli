using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    class CDomanda
    {
		private DatiCondivisi dati;
		public String domanda { get; set; }
		public String risposta { get; set; }
		private int indiceDomanda;
		private String Selezionata;

		public CDomanda()
        {

        }

		public CDomanda(DatiCondivisi dati)
        {
			this.dati = dati;
        }

		public CDomanda(String riga)
		{
			String[] vett = riga.Split(';');
			indiceDomanda = int.Parse(vett[0]);
			domanda = vett[1];
			risposta = vett[2];
		}

		public void setSelezionata(String Selezionata)  //guarda quale domanda è stata selezionata
		{
			this.Selezionata = Selezionata;
		}

		public int[] check()    
		{
			CDomanda C;
			int[] vettIndici;
			C = dati.findDomanda(Selezionata);
			String[] campo = C.risposta.Split('=');
			vettIndici = dati.findPersona(campo[0], campo[1]);
			return vettIndici;
		}
	}
}
