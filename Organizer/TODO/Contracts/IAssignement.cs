using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Contracts
{
   public interface IAssignement 
    {
         string Title { get; }
         string Content { get; }
         DateTime DateOfCreation { get; }
        
    }
}
