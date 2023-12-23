using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza.Model
{
    public class Prognoza
    {
        public Prognoza(int idP, DateTime datum, string geografskaOblast, int sat, int prognoziranaPotrosnja, int ostvarenaPotrosnja, double odstupanje)
        {
            IdP = idP;
            Datum = datum;
            GeografskaOblast = geografskaOblast;
            Sat = sat;
            PrognoziranaPotrosnja = prognoziranaPotrosnja;
            OstvarenaPotrosnja = ostvarenaPotrosnja;
            Odstupanje = odstupanje;
        }
        public Prognoza() { }   
        public int IdP { get; set; }
        public DateTime Datum { get; set; }
        public string GeografskaOblast { get; set; }

        public int Sat { get; set; }
        public int PrognoziranaPotrosnja { get; set; }

        public int OstvarenaPotrosnja { get; set; }

        public double Odstupanje { get; set; }



        //to string

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
