using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Baza
{
    public class ServisBaza : IEvidencija
    {
        public static BazaImpl Baza = BazaImpl.GetBaza();
        public void Audit(Audit audit)
        {
            Baza.InsertAudit(audit);
        }

        public List<string> GeoPodr()
        {
            List<GeoPodrucje> lista = Baza.evidencijaGeoPodrucja();
            List<String> povratna = new List<string>();
            foreach (var item in lista)
            {
                if(!povratna.Contains(item.Sifra))
                {
                    povratna.Add(item.Sifra);
                }
            }

            return povratna;

        }

        public void PrognoziranaaPotrosnja(Prognoza p)
        {
            Baza.InsertPrognoza(p);
        }

        public void upisiOblast(GeoPodrucje geo)
        {
            Baza.InsertGeoPodrucje(geo);
        }
    }
}
