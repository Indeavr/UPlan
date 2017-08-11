using System;
using System.Collections.Generic;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class AddLongTermTaskCommand : Command, ICommand
    {     
        public AddLongTermTaskCommand()
        {
        }

        public override string Execute()
        {
            string title = this.Parameters[0];
            string priority = this.Parameters[1];
            string end = this.Parameters[2];
            string description = this.Parameters[3];

            ILongTermTask longTermTask= base.Factory.CreateLongTermTask(title,priority,end,description);
            
            EngineMaikaTI.CurrentLongTermTask = longTermTask;
            EngineMaikaTI.LoggedUser.AddLongTermTask(longTermTask);

            return Messages.LongTermTaskCreated(title);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Title:"));
            inputParameters.Add(this.ReadOneLine("Priority:"));
            inputParameters.Add(this.ReadOneLine("End Date:"));
            string description = this.ReadOneLine("Description:");

            description = CheckIfThereWasLostDescription(description);
            inputParameters.Add(description);

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
