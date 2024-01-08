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

        public void PrognoziranaaPotrosnja(Prognoza p)
        {
            Baza.InsertPrognoza(p);
        }
    }
}
