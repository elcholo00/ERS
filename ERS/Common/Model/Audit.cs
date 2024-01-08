using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [DataContract]
    public class Audit
    {
       

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Vreme_Pokusaja_ucitavanja { get; set; }

        [DataMember]
        public string Ime { get; set; }

        [DataMember]
        public string Lokacija { get; set; }

        [DataMember]
        public int brojRedova { get; set; }

        public Audit() { }

        public Audit(int idd, DateTime vreme, string ime, string lokacija, int brojRedova)
        {
            this.Id = idd;
            this.Vreme_Pokusaja_ucitavanja = vreme;
            this.Ime = ime;
            this.Lokacija = lokacija;
            this.brojRedova = brojRedova;
        }

        public override string ToString()

        {
            return $"ID: {Id} VREME: {Vreme_Pokusaja_ucitavanja} IME: {Ime} Lokacija: {Lokacija} brojRedova: {brojRedova} ";
        }

    }
}
