using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Baza
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // BazaImpl baza = BazaImpl.GetBaza();


            //Audit a=new Audit(baza.getNextAuditId(),new DateTime(2022,10,10),"ajkgsd","SRB",10);


            //baza.InsertAudit(a);
            //baza.DeleteAudit(a.Id);

            // GeoPodrucje geo = new GeoPodrucje("VOJ", "VOJVODINA", 102032);

            using (ServiceHost host = new ServiceHost(typeof(ServisBaza)))
            {
                host.Open();
                Console.WriteLine("Servis je uspesno pokrenut");
                Console.ReadKey();
            }


        }
    }
}
