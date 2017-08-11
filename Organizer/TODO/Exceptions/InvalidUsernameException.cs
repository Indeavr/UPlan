using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(string message)
            : base(message)
        {

        }
        public InvalidUsernameException() 
            : base()
        {

        }
    }
}
