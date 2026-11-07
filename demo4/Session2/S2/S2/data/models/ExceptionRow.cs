using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2.data.models
{
    public class ExceptionRow
    {
        public string voyageNumber;
        public string containerNumber;
        public string cargoOwner;
        public string exceptionType;
        public string hsCode;
        public string hsDescription;
        public DateTime submitTime;
        public string inspector;
        public string status;   // Pending / Handled / Seized
        public int securityCheckId;
        public bool isDeclarationDiscrepancy;
    }
}
