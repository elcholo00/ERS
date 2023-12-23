using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Baza.Model
{
    public class Audit
    {
        

        public int Id { get; set; }

        public DateTime  Vreme_Pokusaja_ucitavanja { get; set; }

        public string Ime { get; set; }

        public string Lokacija { get; set; }

        public int brojRedova { get; set; }


        public Audit() { }

        public Audit(int idd,DateTime vreme,string ime, string lokacija, int brojRedova)
        {
            this.Id = idd;
            this.Vreme_Pokusaja_ucitavanja = vreme;
            this.Ime = ime;
            this.Lokacija= lokacija;
            this.brojRedova=brojRedova;
        }

        public override string ToString()
        {
            return $"ID: {Id} VREME: {Vreme_Pokusaja_ucitavanja} IME: {Ime} Lokacija: {Lokacija} brojRedova: {brojRedova} ";
        }

    }
}
