using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Evidencija
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IEvidencijaGeo> channel =
                new ChannelFactory<IEvidencijaGeo>("Servis");

            IEvidencijaGeo proxy = channel.CreateChannel();


            UiEvidencija ui = new UiEvidencija(proxy);
            ui.meni();


        }
    }
}
