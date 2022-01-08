using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessWho
{
    public class CPersona
    {
        public int id { get; set; }
        public string nome { get; set; }
        public bool occhiali { get; set; }
        public bool capelli { get; set; }
        public bool barba { get; set; }
        public bool baffi { get; set; }
        public bool nasoGrande { get; set; }
        public bool guanceRosse { get; set; }
        public bool cappello { get; set; }
        public string coloreCapelli { get; set; }
        public string coloreOcchi { get; set; }

        public CPersona(int id, string nome, bool occhiali, bool capelli, bool barba, bool baffi, bool nasoGrande, bool guanceRosse, bool cappello, string coloreCapelli, string coloreOcchi)
        {
            this.id = id;
            this.nome = nome;
            this.occhiali = occhiali;
            this.capelli = capelli;
            this.barba = barba;
            this.baffi = baffi;
            this.nasoGrande = nasoGrande;
            this.guanceRosse = guanceRosse;
            this.cappello = cappello;
            this.coloreCapelli = coloreCapelli;
            this.coloreOcchi = coloreOcchi;
        }
    }
}
