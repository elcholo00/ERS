using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comon
{
    [ServiceContract]
    public interface IEvidencija
    {
        [OperationContract]

        void PrognoziranaaPotrosnja(Prognoza p);

        [OperationContract]

        void Audit(Audit audit);
    }
}
