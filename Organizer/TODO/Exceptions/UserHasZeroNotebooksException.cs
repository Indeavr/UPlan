using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Exceptions
{
    public class UserHasZeroNotebooksException:Exception
    {
        public UserHasZeroNotebooksException(string message)
            : base(message)
        {

        }
        public UserHasZeroNotebooksException()
           : base()
        {

        }
    }
}
