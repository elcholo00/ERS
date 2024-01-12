using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class ServisEvidencijaGeo : IEvidencijaGeo
    {
        BazaImpl baza = BazaImpl.GetBaza();
        public List<GeoPodrucje> evidencija()
        {
            return baza.evidencijaGeoPodrucja();
        }

        public void ubaci(GeoPodrucje geo)
        {
            baza.InsertGeoPodrucje(geo);
        }
    }
}
