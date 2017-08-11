using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Exceptions
{
    public class InvalidPriorityException:Exception
    {
        public InvalidPriorityException(string message)
            : base(message)
        {

        }
        public InvalidPriorityException()
           : base()
        {

        }
    }
}
