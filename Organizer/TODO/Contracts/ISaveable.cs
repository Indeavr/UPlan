using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Contracts
{
    public interface ISaveable
    {
        string FormatUserInfoForDB();
    }
}
