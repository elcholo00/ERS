using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza.Model;

namespace Baza
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BazaImpl baza = BazaImpl.GetBaza();

            Audit a=new Audit(baza.getNextAuditId(),new DateTime(2022,10,10),"ajkgsd","SRB",10);


            baza.InsertAudit(a);
           // baza.DeleteAudit(a.Id);



        }
    }
}
