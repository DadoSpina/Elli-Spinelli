using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    class CPersona
    {
        /*
         * capelliL-capelliC-occhi-carnagione-barba-nei-occhiali-lentiggini
         */

        public String[] vetCaratteristiche { get; set; } = {"id", "nome", "capelliL", "capelliC", "occhi", "carnagione", "barba", "nei", "occhiali", "lentiggini" };
        public int id { get; set; }
        public string nome { get; set; }
        public string capelliL { get; set; }
        public string capelliC { get; set; }
        public string occhi { get; set; }
        public string carnagione { get; set; }
        public string barba { get; set; }
        public string nei { get; set; }
        public string occhiali { get; set; }
        public string lentiggini { get; set; }

        public CPersona()
        {

        }

        public CPersona(int id, string nome, string capelliL, string capelliC, string occhi, string carnagione, string barba, string nei, string occhiali, string lentiggini)
        {
            this.id = id;
            this.nome = nome;
            this.capelliL = capelliL;
            this.capelliC = capelliC;
            this.occhi = occhi;
            this.carnagione = carnagione;
            this.barba = barba;
            this.nei = nei;
            this.occhiali = occhiali;
            this.lentiggini = lentiggini;
        }

        /*public CPersona(string riga)
        {
            String[] vett = riga.Split(';');
            id = int.Parse(vett[0]);
            nome = vett[1];
            String[] campo = vett[2].Split(',');
            for (int i=0; i<campo.Length; i++)
            {
                String[] s = campo[i].Split('=');
                switch (i)
                {
                    case 0:
                        capelliL=s[1];
                        break;
                    case 1:
                        capelliC=s[1];
                        break;
                    case 2:
                        occhi=s[1];
                        break;
                    case 3:
                        carnagione = s[1];
                        break;
                    case 4:
                        barba = s[1];
                        break;
                    case 5:
                        nei = s[1];
                        break;
                    case 6:
                        occhiali = s[1];
                        break;
                    case 7:
                        lentiggini = s[1];
                        break;
                }
            }
        }*/

    }
}
