using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class KlantException : Exception
    {
        public KlantException(string message) : base(message)
        {
        }

        public KlantException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
