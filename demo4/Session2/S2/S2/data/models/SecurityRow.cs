using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2.data.models
{
    public class SecurityRow
    {
        
            public int securityCheckId;
            public string containerNumber;
            public string hsCode;
            public string hsDescription;
            public int cargoOwnerId;
            public string cargoOwner;
            public string rating;
            public string riskGrade;
            public string status;      // "Not Started" for containers without check
            public int? riskScore;
        public string voyageNumber;
        
    }
}
