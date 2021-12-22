using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions {
    public class ClubRepositoryADOEXCEPTION : Exception {
        public ClubRepositoryADOEXCEPTION(string message) : base(message) {
        }
            public ClubRepositoryADOEXCEPTION(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
