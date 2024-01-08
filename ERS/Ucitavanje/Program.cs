using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Comon;
using Comon.Model;

namespace Ucitavanje
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ChannelFactory<IEvidencija> channel =
                new ChannelFactory<IEvidencija>("ServisBaza");

            IEvidencija proxy = channel.CreateChannel();

            UIHandler Ui = new UIHandler(proxy);
            Ui.meni();

            Console.Read();
        }
    }
}
