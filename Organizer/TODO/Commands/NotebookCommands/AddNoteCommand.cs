using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class AddNoteCommand : Command, ICommand
    {
        public AddNoteCommand()
            : base()
        {

        }

        public override string Execute()
        {
            string title = base.Parameters[0];
            string content = base.Parameters[1];
            INote note = this.Factory.CreateNote(title,content);
            EngineMaikaTI.CurrentNotebook.AddNote(note);

            return Messages.NoteCreated(title);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Title: "));
            
            string content = this.ReadOneLine("Content: ");
            content = CheckIfThereWasLostDescription(content);
            inputParameters.Add(content);
            EngineMaikaTI.LastDescription = content;
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
