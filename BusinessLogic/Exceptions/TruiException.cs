using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class TruiException : Exception
    {
        public TruiException(string message) : base(message)
        {
        }

        public TruiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
