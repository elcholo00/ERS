using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Comon;

namespace Baza
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ServiceHost host = new ServiceHost(typeof(ServisBaza));

            host.AddServiceEndpoint(typeof(IEvidencija),
                 new NetTcpBinding(),
               new Uri("net.tcp://localhost:4000/IEvidencija"));
            host.Open();
            Console.WriteLine("Servis1 je uspesno pokrenut");


            ServiceHost host1 = new ServiceHost(typeof(ServisIspiscs));
            
                host1.AddServiceEndpoint(typeof(IIspis),
                 new NetTcpBinding(),
               new Uri("net.tcp://localhost:4001/IIspis"));

                host1.Open();
                Console.WriteLine("Servis2 je uspesno pokrenut");


            ServiceHost host2 = new ServiceHost(typeof(ServisEvidencijaGeo));

            host2.AddServiceEndpoint(typeof(IEvidencijaGeo),
             new NetTcpBinding(),
           new Uri("net.tcp://localhost:4002/IEvidencijaGeo"));

            host2.Open();
            Console.WriteLine("Servis2 je uspesno pokrenut");
            Console.ReadKey();
            

            

        }
    }
}
