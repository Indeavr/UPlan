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
    public class DeleteLongTermTaskCommand : Command, ICommand
    {
        public override string Execute()
        {
            string longTermTaskName = this.Parameters[0];
            string subTaskName = this.Parameters[1];
            if (EngineMaikaTI.LoggedUser.LongTermTasks.Any(x => x.Title == longTermTaskName))
            {
                ILongTermTask currLongTermTask = EngineMaikaTI.LoggedUser.LongTermTasks.First(x => x.Title == longTermTaskName);
                EngineMaikaTI.LoggedUser.LongTermTasks.Remove(currLongTermTask);
                return Messages.TaskRemoved(subTaskName);              
            }
            return Messages.NoLongTermTaskFound();
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add("Long term task name: ");      
            this.Parameters = inputParameters;
        }
    }
}
