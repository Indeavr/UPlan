using System.Collections.Generic;
using System.Linq;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class ListTask : Command, ICommand
    {
        public override string Execute()
        {
            string inputTitle = base.Parameters[0];

            if (!FindTask(inputTitle))
            {
                return Messages.InvalidTaskName();
            }
            return EngineMaikaTI.LoggedUser.Tasks.First(t => t.Title == inputTitle).ToString();
        }

        private bool FindTask(string inputTitle)
        {
            if (EngineMaikaTI.LoggedUser.Tasks.Any(x => x.Title == inputTitle))
            {
                return true;
            }
            return false;
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Task name: "));
            this.Parameters = inputParameters;
        }
    }
}
