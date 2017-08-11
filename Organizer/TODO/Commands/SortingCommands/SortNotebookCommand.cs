using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class SortNotebookCommand : Command, ICommand
    {
        public override string Execute()
        {
            string notebookName = base.Parameters[0];
            string sortType = base.Parameters[1];
            if (EngineMaikaTI.LoggedUser.Notebooks.All(n => n.Name != notebookName))
            {
                return Messages.WrongNotebookName();
            }

            switch (sortType.ToLower())
            {
                case "nameas":
                    EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).Notes =
                        EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).Notes
                            .OrderBy(a => a.Title).ToList();
                    break;
                case "nameds":
                    EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).Notes =
                        EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).Notes
                            .OrderByDescending(a => a.Title).ToList();
                    break;
                case "fav":
                    EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).Notes =
                        EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).Notes
                            .OrderByDescending(a => a.IsFavourite).ToList();
                    break;
                case "date":
                    EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).Notes =
                        EngineMaikaTI.LoggedUser.Notebooks.First(n => n.Name == notebookName).Notes
                            .OrderByDescending(a => a.DateOfCreation).ToList();
                    break;
            }


            return Messages.SortedSuccessfully(sortType);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Notebook name: "));
            inputParameters.Add(this.ReadOneLine("Way to Sort (nameAS, nameDS, Fav, date): "));
            this.Parameters = inputParameters;
        }
    }
}
