using System;
using System.Collections.Generic;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class AddSubtaskCommand : Command, ICommand
    {
        public AddSubtaskCommand() 
            : base()
        {
        }

        public override string Execute()
        {
            string title = this.Parameters[0];
            string priority = this.Parameters[1];
            string end = this.Parameters[2];
            string description = this.Parameters[3];
            string importancePercent = this.Parameters[4];
            ISubTask currSubtask= this.Factory
                .CreateSubTask(title, priority, end, description, importancePercent);
            
            EngineMaikaTI.CurrentLongTermTask.AddSubTask(currSubtask);

            return Messages.SubTaskCreated(title);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Title: "));
            inputParameters.Add(this.ReadOneLine("Priority: "));
            inputParameters.Add(this.ReadOneLine("End date: "));

            string description = this.ReadOneLine("Description: ");
            description = CheckIfThereWasLostDescription(description);
            inputParameters.Add(description);

            inputParameters.Add(this.ReadOneLine("Importance percent: "));

            EngineMaikaTI.LastDescription = description;
            this.Parameters = inputParameters;
        }

        private string CheckIfThereWasLostDescription(string description)
        {
            if (description == "last" && EngineMaikaTI.LastDescription != null)
            {
                return EngineMaikaTI.LastDescription;
            }
            return description;
        }
    }
}
