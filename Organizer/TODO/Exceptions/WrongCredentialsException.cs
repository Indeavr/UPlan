using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Exceptions
{
    public class WrongCredentialsException: Exception
    {
        public WrongCredentialsException(string message)
            :base(message)
        {

        }
        public WrongCredentialsException()
            : base()
        {

        }
    }
}
