using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class ClubSetException : Exception
    {
        public ClubSetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
