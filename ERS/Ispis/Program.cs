using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Comon;
using Comon.Model;

namespace Ispis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ChannelFactory<IIspis> channel =
                new ChannelFactory<IIspis>("ServisBaza");

            IIspis proxy = channel.CreateChannel();

            Audit a = new Audit(1, new DateTime(2022, 10, 10), "ahsdjkas1", "jkhakjshdjkhkahsd", 25);
            Audit a1 = new Audit(2, new DateTime(2022, 11, 10), "ahsdjkas2", "jkhakjshdjkhkahsd", 25);
            Audit a2 = new Audit(3, new DateTime(2022, 12, 10), "ahsdjkas3", "jkhakjshdjkhkahsd", 25);

            //proxy.Audit(a);
            //proxy.Audit(a1);
           // proxy.Audit(a2);


            Prognoza p = new Prognoza(1, new DateTime(2022, 10, 10), "GEO", 23, 10, 20, 10);

           // proxy.PrognoziranaaPotrosnja(p);

            Console.Read();
        }
    }
}
