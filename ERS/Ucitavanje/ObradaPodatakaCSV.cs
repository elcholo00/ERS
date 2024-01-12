using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Ucitavanje
{
    public class ObradaPodatakaCSV : Obradacs
    {
        public ObradaPodatakaCSV(IEvidencija proxy)
        { 
            Proxy = proxy;
        }
        public override void ObradaFajla(string putanja)
        {
            Console.WriteLine($"Obrada CSV fajla na putanji: {putanja}");
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
                Console.WriteLine($"Nevalidan sadržaj CSV fajla: {imeFajla}");
                EvidentirajNevalidanFajl(imeFajla, putanja, brojRedova);
                return;
            }

            // Pretpostavljam da imate funkciju ObradiValidnePodatkeCSV koja je slična onoj za XML i TXT, ali prilagođena za CSV format.
            ObradiValidnePodatke(putanja, tipFajla, datum);
        }

        public override void ObradiValidnePodatke(string putanja, string tipFajla, DateTime datum)
        {
            string[] linije = File.ReadAllLines(putanja);


            for (int i = 1; i < linije.Length; i++)
            {

                string[] delovi = linije[i].Split(',');

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
                if(!lista.Contains(delovi[2]))
                {
                    GeoPodrucje geo = new GeoPodrucje();
                    geo.Sifra = delovi[2];
                    geo.Ime= delovi[2];
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

       
      

        public override bool ValidirajSadrzaj(string putanja, out int brojRedova)
        {
            XDocument xmlDokument = XDocument.Load(putanja);
            brojRedova = 0;
            bool povratna = true;

            var sveOblasti = xmlDokument.Descendants("OBLAST").Select(o => o.Value).Distinct().ToList();

            foreach (var oblast in sveOblasti)
            {

                var redoviZaOblast = xmlDokument.Descendants("STAVKA").Where(s => s.Element("OBLAST").Value == oblast).ToList();
                brojRedova += redoviZaOblast.Count();
                if (redoviZaOblast.Count != 24 && redoviZaOblast.Count != 23 && redoviZaOblast.Count != 25)
                {

                    povratna = false;
                }


            }

            return povratna;
        }
    }
}
