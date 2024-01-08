using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [DataContract]
    public class Prognoza
    {
        public Prognoza(int idP, DateTime datum, string geografskaOblast, DateTime sat, double prognoziranaPotrosnja, double ostvarenaPotrosnja, double odstupanje)
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

        [DataMember]
        public int IdP { get; set; }

        [DataMember]
        public DateTime Datum { get; set; }

        [DataMember]
        public string GeografskaOblast { get; set; }

        [DataMember]

        public DateTime Sat { get; set; }

        [DataMember]
        public double PrognoziranaPotrosnja { get; set; }

        [DataMember]

        public double OstvarenaPotrosnja { get; set; }

        [DataMember]

        public double Odstupanje { get; set; }



        //to string

        public override string ToString()
        {
            return $"ID: {IdP} DATUM: {Datum} GEOOBLAST: {GeografskaOblast} SAT: {Sat} PROGNOZIRANA POTROSNJA: {PrognoziranaPotrosnja} " +
                $"OSTVARENA POTROSNJA: {OstvarenaPotrosnja} ODSTUPANJE: {Odstupanje} ";
        }
    }
}
