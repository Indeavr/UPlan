using System.Collections.Generic;
using System.Linq;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands.TaskCommands
{
    public class DeleteSubTaskCommand : Command, ICommand
    {
        public override string Execute()
        {
            string longTermTaskName = this.Parameters[0];
            string subTaskName = this.Parameters[1];
            if (EngineMaikaTI.LoggedUser.LongTermTasks.Any(x => x.Title == longTermTaskName))
            {
                ILongTermTask currLongTermTask = EngineMaikaTI.LoggedUser.LongTermTasks.First(x => x.Title == longTermTaskName);
                if (currLongTermTask.AllTasks.Any(x => x.Title == subTaskName))
                {
                    ISubTask subTaskToRemove = currLongTermTask.AllTasks.First(x => x.Title == subTaskName);
                    currLongTermTask.AllTasks.Remove(subTaskToRemove);
                    return Messages.TaskRemoved(subTaskName);
                }
                return Messages.NoSubtaskFound();
            }
            return Messages.NoLongTermTaskFound();
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add("Long term task name: ");
            inputParameters.Add("Subtask name: ");
            this.Parameters = inputParameters;
        }
    }
}
