using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Exceptions
{
    public class CannotBeNullException :ArgumentNullException
    {
        public CannotBeNullException(string message)
            : base(message)
        {

        }
        public CannotBeNullException()
            : base()
        {

        }
    }
}
