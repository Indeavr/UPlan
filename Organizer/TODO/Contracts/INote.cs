using System;

namespace TODO.Contracts
{
    public interface INote: IAssignement,ISaveable
    {     
        bool IsFavourite { get; set; }
    }
}
