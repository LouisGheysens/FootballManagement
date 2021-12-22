using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions {
    public class BestellingRepositoryADOException : Exception {
        public BestellingRepositoryADOException(string message) : base(message) {
        }
        public BestellingRepositoryADOException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
