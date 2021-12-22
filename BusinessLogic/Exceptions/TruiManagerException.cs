using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions {
    public class TruiManagerException : Exception {
        public TruiManagerException(string message) : base(message) {
        }

        public TruiManagerException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
