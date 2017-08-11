using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    class AddNotebookToFavouritesCommand : Command, ICommand
    {
        public override string Execute()
        {
            string notebookTitle = base.Parameters[0];

            if (EngineMaikaTI.LoggedUser.Notebooks.All(x => x.Name != notebookTitle))
            {
                return Messages.WrongNotebookName();
            }
                
            EngineMaikaTI.LoggedUser.Notebooks.First(x => x.Name == notebookTitle).IsFavourite = true;
            return Messages.NotebookAddedToFavourites();
        }

        public override void TakeInput()
        {
            List<string> parameters = new List<string>();
            parameters.Add(ReadOneLine("Notebook Title: "));
            base.Parameters = parameters;
        }
    }
}
