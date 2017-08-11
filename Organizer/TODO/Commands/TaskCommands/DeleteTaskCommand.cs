using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands.TaskCommands
{
    public class DeleteTaskCommand : Command, ICommand
    {
        public override string Execute()
        {
            string taskName = this.Parameters[0];
            if (EngineMaikaTI.LoggedUser.Tasks.Any(x => x.Title == taskName))
            {
                ITask taskToRemove = EngineMaikaTI.LoggedUser.Tasks.First(x => x.Title == taskName);
                EngineMaikaTI.LoggedUser.Tasks.Remove(taskToRemove);
                return Messages.TaskRemoved(taskName);
            }
            return Messages.InvalidTaskName();
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Task name: "));
            this.Parameters = inputParameters;
        }
    }
}
