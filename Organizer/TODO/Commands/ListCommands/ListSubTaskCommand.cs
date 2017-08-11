using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class ListSubTaskCommand: Command, ICommand
    {
        public override string Execute()
        {
            string subTaskTitle = base.Parameters[0];

            if (!FindSubTask(subTaskTitle))
            {
                return Messages.NoSubtaskFound();
            }

            return EngineMaikaTI.LoggedUser.LongTermTasks
                .Select(nb => nb.AllTasks.FirstOrDefault(n => n.Title == subTaskTitle))
                .First(x => x != null)
                .ToString();
        }

        private bool FindSubTask(string subTaskTitle)
        {
            if (EngineMaikaTI.LoggedUser.LongTermTasks
                .Any(x => x.AllTasks.Any(n => n.Title == subTaskTitle)))
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
