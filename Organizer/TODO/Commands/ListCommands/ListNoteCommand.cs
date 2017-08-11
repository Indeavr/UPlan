using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class ListNoteCommand : Command, ICommand
    {
        public override string Execute()
        {
            string noteTitle = base.Parameters[0];

            if (!FindNote(noteTitle))
            {
                return Messages.WrongNoteTitle();
            }
            return EngineMaikaTI.LoggedUser.Notebooks
                .Select(nb => nb.Notes.FirstOrDefault(n => n.Title == noteTitle))
                .First(x => x != null)
                .ToString();
        }

        private bool FindNote(string noteTitle)
        {
            if (EngineMaikaTI.LoggedUser.Notebooks
                .Any(x => x.Notes.Any(n => n.Title == noteTitle)))
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
