using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class SortTasksCommand : Command, ICommand
    {
        public override string Execute()
        {
            string sortType = base.Parameters[0];

            switch (sortType.ToLower())
            {
                case "nameas":
                    EngineMaikaTI.LoggedUser.Tasks = EngineMaikaTI.LoggedUser.Tasks
                        .OrderBy(a => a.Title).ToList();
                    break;
                case "nameds":
                    EngineMaikaTI.LoggedUser.Tasks = EngineMaikaTI.LoggedUser.Tasks
                        .OrderByDescending(a => a.Title).ToList();
                    break;

                case "date":
                    EngineMaikaTI.LoggedUser.Tasks = EngineMaikaTI.LoggedUser.Tasks
                        .OrderByDescending(a => a.DateOfCreation).ToList();
                    break;

                case "reminder":
                    EngineMaikaTI.LoggedUser.Tasks = EngineMaikaTI.LoggedUser.Tasks
                        .OrderByDescending(a => a.Reminder.MomentToRemind.TotalSeconds)
                        .ToList();
                    break;

                case "priority":
                    EngineMaikaTI.LoggedUser.Tasks = EngineMaikaTI.LoggedUser.Tasks
                        .OrderByDescending(a => a.Priority)
                        .ToList();
                    break;
            }

            return Messages.SortedSuccessfully(sortType);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Way to Sort (nameAS, nameDS, date, reminder, priority): "));
            this.Parameters = inputParameters;
        }
    }
}
