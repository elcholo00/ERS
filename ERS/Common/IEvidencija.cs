using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IEvidencija
    {
        [OperationContract]

        void PrognoziranaPotrosnja(Prognoza p);

        [OperationContract]

        void Audit(Audit audit);
    }
}
