using System.Collections.Generic;
using System.Linq;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class SwitchNotebookCommand : Command, ICommand
    {
        public SwitchNotebookCommand()
            : base()
        {
        }

        public override string Execute()
        {
            string notebookName = base.Parameters[0];

            if (EngineMaikaTI.LoggedUser.Notebooks.Any(x=>x.Name==notebookName))
            {
                EngineMaikaTI.CurrentNotebook = EngineMaikaTI.LoggedUser.Notebooks.First(x => x.Name == notebookName);
                return Messages.NotebookSwitched(notebookName);
            }
            return Messages.WrongNotebookName();
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Notebook name: "));
            this.Parameters = inputParameters;
        }
    }
}
