using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class CompetitieException : Exception
    {
        public CompetitieException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
