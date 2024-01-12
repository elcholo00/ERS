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
                new ChannelFactory<IIspis>("Servis");

            IIspis proxy = channel.CreateChannel();
            //2020-05-07 00:00:00.000
            List<List<Prognoza>> lista = proxy.Izracunaj(new DateTime(2020,5,7,0,0,0),"BGD");



            
            


            List<Prognoza> izracunato=new List<Prognoza>();


            for (int i = 0;i< lista[0].Count;i++)
            {
                Prognoza p=new Prognoza();

                float odstupanje = (Math.Abs(lista[0][i].OPotrosnja - lista[1][i].PPotrosnja) / lista[0][i].OPotrosnja )* 100.0f;

                p.PPotrosnja = lista[1][i].PPotrosnja;
                p.OPotrosnja = lista[0][i].OPotrosnja;
                p.Odstupanje = odstupanje;
                p.GeografskaOblast= lista[1][i].GeografskaOblast;
                p.Sat= lista[1][i].Sat;
                p.Datum= lista[0][i].Datum;
                izracunato.Add(p);

            }


            foreach (var item in izracunato)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}
