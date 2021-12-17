using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    class CPersona
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string capelli { get; set; }
        public string occhi { get; set; }

        public CPersona(int id, string nome, string capelli, string occhi)
        {
            this.id = id;
            this.nome = nome;
            this.capelli = capelli;
            this.occhi = occhi;
        }


    }
}
