using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
    [DataContract]
    public class Audit
    {


        

        [DataMember]
        public DateTime Vreme_Pokusaja_ucitavanja { get; set; }

        [DataMember]
        public string Ime { get; set; }

        [DataMember]
        public string Lokacija { get; set; }

        [DataMember]
        public int brojRedova { get; set; }

        public Audit() { }

        public Audit( DateTime vreme, string ime, string lokacija, int brojRedova)
        {
            
            this.Vreme_Pokusaja_ucitavanja = vreme;
            this.Ime = ime;
            this.Lokacija = lokacija;
            this.brojRedova = brojRedova;
        }

        public override string ToString()

        {
            return $"VREME: {Vreme_Pokusaja_ucitavanja} IME: {Ime} Lokacija: {Lokacija} brojRedova: {brojRedova} ";
        }

    }
}
