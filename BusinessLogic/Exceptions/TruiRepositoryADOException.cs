using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions {
    public class TruiRepositoryADOException : Exception {
        public TruiRepositoryADOException(string message) : base(message) {
        }
        public TruiRepositoryADOException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
