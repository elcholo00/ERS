using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class ServisIspiscs : IIspis
    {
        BazaImpl baza = BazaImpl.GetBaza();
        public List<List<Prognoza>> Izracunaj(DateTime datum, string GeoPodrucje)
        {
            List<Prognoza> ostvarene = baza.OstvGeoPodrucje(datum, GeoPodrucje);
            List<Prognoza> prognozirne = baza.ProgGeoPodrucje(datum, GeoPodrucje);

            List < List <Prognoza>> povratna=new List<List<Prognoza>>();
            povratna.Add(ostvarene);
            povratna.Add(prognozirne);


            return povratna;
        }

     
    }
}
