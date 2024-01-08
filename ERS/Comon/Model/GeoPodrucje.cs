using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
    [DataContract]
    public class GeoPodrucje
    {
        public GeoPodrucje() { }
        public GeoPodrucje(string sifra, string ime, int sirina)
        {
            this.Sifra = sifra;
            this.Ime = ime;
            this.Sirina = sirina;
        }

        [DataMember]
        public string Sifra { get; set; }

        [DataMember]
        public string Ime { get; set; }

        [DataMember]

        public int Sirina { get; set; }

        public override string ToString()

        {
            return $"SIFRA: {Sifra} IME: {Ime} SIRINA: {Sirina} ";
        }


    }
}
