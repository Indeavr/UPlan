using System.Collections.Generic;
using System.Linq;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class ListNotebookCommand : Command, ICommand
    {
        public override string Execute()
        {
            string notebookName = base.Parameters[0];

            if (!FindNotebook(notebookName))
            {
                return Messages.WrongNotebookName();
            }
            return EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).ToString();
        }

        private bool FindNotebook(string inputTitle)
        {
            if (EngineMaikaTI.LoggedUser.Notebooks.Any(n => n.Name == inputTitle))
            {
                return true;
            }
            return false;
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Notebook Name: "));
            this.Parameters = inputParameters;
        }
    }
}
