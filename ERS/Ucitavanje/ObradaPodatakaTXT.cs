using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucitavanje
{
    public class ObradaPodatakaTXT : Obradacs
    {
        public ObradaPodatakaTXT(IEvidencija proxy) { 
            Proxy= proxy;
        }
        public override void ObradaFajla(string putanja)
        {
            Console.WriteLine($"Obrada TXT fajla na putanji: {putanja}");
            string imeFajla = Path.GetFileNameWithoutExtension(putanja);
            string tipFajla;
            DateTime datum;

            if (!ValidirajImeFajla(imeFajla, out tipFajla, out datum))
            {
                return;
            }

            Console.WriteLine($"Tip Fajla: {tipFajla}, Datum: {datum}");
            int brojRedova = 0;

            if (!ValidirajSadrzaj(putanja, out brojRedova))
            {
                Console.WriteLine($"Nevalidan sadržaj TXT fajla: {imeFajla}");
                EvidentirajNevalidanFajl(imeFajla, putanja, brojRedova);
                return;
            }

            // Pretpostavljam da imate funkciju ObradiValidnePodatkeTxt koja je slična onoj za XML, ali prilagođena za TXT format.
            ObradiValidnePodatke(putanja, tipFajla, datum);
        }

        public override void ObradiValidnePodatke(string putanja, string tipFajla, DateTime datum)
        {
            string[] linije = File.ReadAllLines(putanja);

            foreach (var linija in linije)
            {

                string[] delovi = linija.Split(',');

                if (delovi.Length != 3)
                {

                    continue;
                }

                int sat;
                float potrosnja;

                if (!int.TryParse(delovi[0], out sat) || !float.TryParse(delovi[1], out potrosnja))
                {

                    continue;
                }
                List<string> lista = Proxy.GeoPodr();
                if (!lista.Contains(delovi[2]))
                {
                    GeoPodrucje geo = new GeoPodrucje();
                    geo.Sifra = delovi[2];
                    geo.Ime = delovi[2];
                    Proxy.upisiOblast(geo);
                }

                string geografskaOblast = delovi[2];

                float prognoziranaP = 0;
                float ostvarenaP = 0;

                if (tipFajla == "prog")
                {
                    prognoziranaP = potrosnja;
                }
                else if (tipFajla == "ostv")
                {
                    ostvarenaP = potrosnja;
                }

                Prognoza novaPotrosnja = new Prognoza(datum, geografskaOblast, sat, prognoziranaP, ostvarenaP, 0);
                Console.WriteLine(novaPotrosnja);

                UpisiUBazuPotrosnja(novaPotrosnja);
            }
        }

       

        public override bool ValidirajSadrzaj(string putanja, out int BrojRedova)
        {
            BrojRedova = 0;
            bool povratna = true;
            string[] linije = File.ReadAllLines(putanja);


            Dictionary<string, int> brojRedovaPoOblasti = new Dictionary<string, int>();


            foreach (var linija in linije)
            {

                string[] delovi = linija.Split(',');

                if (delovi.Length != 3)
                {
                    povratna = false;
                }

                string oblast = delovi[2];


                if (brojRedovaPoOblasti.ContainsKey(oblast))
                {
                    brojRedovaPoOblasti[oblast]++;
                }
                else
                {
                    brojRedovaPoOblasti[oblast] = 1;
                }
            }


            foreach (var brojRedova in brojRedovaPoOblasti.Values)
            {
                if (brojRedova != 23 && brojRedova != 24 && brojRedova != 25)
                {
                    povratna = false;
                }
                BrojRedova += brojRedova;
            }

            return povratna;
        }
    }
}
