using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    class AddNoteToFavouritesCommand : Command, ICommand
    {

        public override string Execute()
        {
            string notebookTitle = base.Parameters[0];
            string noteName = base.Parameters[1];

            if (EngineMaikaTI.LoggedUser.Notebooks.Any(x => x.Name == notebookTitle))
            {
                if (EngineMaikaTI.LoggedUser.Notebooks
                    .First(n => n.Name == notebookTitle).Notes.Any(note => note.Title == noteName))
                {
                    EngineMaikaTI.LoggedUser.Notebooks
                        .First(x => x.Name == notebookTitle).Notes
                        .First(n => n.Title == noteName).IsFavourite = true;
                }
                else
                    return Messages.WrongNoteTitle();
            }
            else
                return Messages.WrongNotebookName();

            return Messages.NoteAddedToFavourites();

        }

        public override void TakeInput()
        {
            List<string> parameters = new List<string>();
            parameters.Add(ReadOneLine("Notebook Title: "));
            parameters.Add(ReadOneLine("Note Title: "));
            base.Parameters = parameters;
        }
    }
}
