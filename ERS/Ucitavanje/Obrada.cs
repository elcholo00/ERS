using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ucitavanje
{
    public abstract class Obradacs
    {
        public IEvidencija Proxy;
        public abstract void ObradaFajla(string putanja);
        public bool ValidirajImeFajla(string imeFajla, out string tipFajla, out DateTime datum)
        {
            tipFajla = "";
            datum = DateTime.MinValue;

            string[] deloviImena = imeFajla.Split('_');

            if (deloviImena.Length != 4)
            {
                Console.WriteLine($"Nevalidan format imena fajla: {imeFajla}");
                return false;
            }

            tipFajla = deloviImena[0];

            string datumString = $"{deloviImena[1]}_{deloviImena[2]}_{deloviImena[3]}";

            if (!DateTime.TryParseExact(datumString, "yyyy_MM_dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datum))
            {
                Console.WriteLine($"Nevalidan format datuma: {datumString}");
                return false;
            }

            return true;
        }
        public abstract bool ValidirajSadrzaj(string putanja, out int brojRedova);
        public abstract void ObradiValidnePodatke(string putanja, string tipFajla, DateTime datum);
        public void EvidentirajNevalidanFajl(string imeFajla, string putanja, int brojRedova)
        {
            DateTime vremeUcitavanja = DateTime.Now;


            Audit auditZapis = new Audit(vremeUcitavanja, imeFajla, putanja, brojRedova);


            Console.WriteLine($"Nevalidan fajl: {imeFajla}, Lokacija: {putanja}, Broj redova: {brojRedova}");
            UpisiUBazuAudit(auditZapis);
        }
        public  void UpisiUBazuPotrosnja(Prognoza potrosnja)
        {
            Proxy.PrognoziranaaPotrosnja(potrosnja);
        }
        public  void UpisiUBazuAudit(Audit audit)
        {
            Proxy.Audit(audit);
        }


    }
}
