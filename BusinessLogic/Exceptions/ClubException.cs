using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class ClubException: Exception
    {
        public ClubException(string message) : base(message)
        {
        }

        public ClubException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
