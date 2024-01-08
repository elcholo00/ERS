using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
    [DataContract]
    public class Prognoza
    {
        public Prognoza( DateTime datum, string geografskaOblast, int sat, float prognoziranaPotrosnja, float ostvarenaPotrosnja, float odstupanje)
        {
            
            Datum = datum;
            GeografskaOblast = geografskaOblast;
            Sat = sat;
            PPotrosnja = prognoziranaPotrosnja;
            OPotrosnja = ostvarenaPotrosnja;
            Odstupanje = odstupanje;
        }
        public Prognoza() { }

        

        [DataMember]
        public DateTime Datum { get; set; }

        [DataMember]
        public string GeografskaOblast { get; set; }

        [DataMember]

        public int Sat { get; set; }

        [DataMember]
        public float PPotrosnja { get; set; }

        [DataMember]

        public float OPotrosnja { get; set; }

        [DataMember]

        public float Odstupanje { get; set; }



        //to string

        public override string ToString()
        {
            return $" DATUM: {Datum} GEOOBLAST: {GeografskaOblast} SAT: {Sat} PROGNOZIRANA POTROSNJA: {PPotrosnja} " +
                $"OSTVARENA POTROSNJA: {OPotrosnja} ODSTUPANJE: {Odstupanje} ";
        }
    }
}
