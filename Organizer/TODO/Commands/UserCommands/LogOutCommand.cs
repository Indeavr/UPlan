using System;
using System.Collections.Generic;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class LogOutCommand : Command, ICommand
    {

        public LogOutCommand()
            : base()
        {
        }

        public override string Execute()
        {
            EngineMaikaTI.LoggedUser = null;
            return Messages.LoggedOut();
        }

        public override void TakeInput()
        {           
        }
    }
}
