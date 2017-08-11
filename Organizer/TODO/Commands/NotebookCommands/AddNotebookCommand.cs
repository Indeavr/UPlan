using System;
using System.Collections.Generic;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class AddNotebookCommand : Command, ICommand
    {
        public AddNotebookCommand()
            : base()
        {
        }

        public override string Execute()
        {
            string notebookName = base.Parameters[0];
            INotebook notebook = base.Factory.CreateNotebook(notebookName);
            EngineMaikaTI.LoggedUser.AddNotebook(notebook);
            EngineMaikaTI.CurrentNotebook = notebook;

            return Messages.NotebookCreated(notebookName);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Notebook name: "));
            this.Parameters = inputParameters; 
        }
    }
}
