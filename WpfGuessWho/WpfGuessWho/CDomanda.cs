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
		public String domanda { get; set; }
		public String risposta { get; set; }
		public int indiceDomanda { get; set; }
		private int indiceSelezionata;

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

		public void setSelezionata(int indiceSelezionata)  //guarda quale domanda è stata selezionata
		{
			this.indiceSelezionata = indiceSelezionata;
		}

		public int[] check()    
		{
			CDomanda C;
			int[] vettIndici;
			C = dati.findDomanda(indiceSelezionata);
			String[] campo = C.risposta.Split('=');
			vettIndici = dati.findPersona(campo[0], campo[1]);
			return vettIndici;
		}
	}
}
