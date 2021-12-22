using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions {
    public class KlantRepositoryADOException : Exception {
        public KlantRepositoryADOException(string message) : base(message) {
        }

        public KlantRepositoryADOException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
