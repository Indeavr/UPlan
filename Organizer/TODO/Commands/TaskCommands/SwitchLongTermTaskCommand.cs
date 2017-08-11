using System.Collections.Generic;
using System.Linq;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO
{
    public class SwitchLongTermTaskCommand : Command, ICommand
    {
        public override string Execute()
        {
            string longTermTaskCommand = base.Parameters[0];

            if (EngineMaikaTI.LoggedUser.LongTermTasks.Any(x=>x.Title==longTermTaskCommand))
            {
                EngineMaikaTI.CurrentLongTermTask = EngineMaikaTI.LoggedUser.LongTermTasks.First(x => x.Title == longTermTaskCommand);
                return Messages.NotebookSwitched(longTermTaskCommand);
            }
            return Messages.WrongNotebookName();
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Long term task name: "));
            this.Parameters = inputParameters;
        }
    }
}
