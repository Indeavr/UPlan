using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class SortNotebooksCommand : Command, ICommand
    {
        public override string Execute()
        {
            string sortingType = base.Parameters[0];
            switch (sortingType.ToLower())
            {
                case "nameas":
                    EngineMaikaTI.LoggedUser.Notebooks = EngineMaikaTI.LoggedUser.Notebooks.OrderBy(a => a.Name).ToList();
                    break;
                case "nameds":
                    EngineMaikaTI.LoggedUser.Notebooks = EngineMaikaTI.LoggedUser.Notebooks.OrderByDescending(a => a.Name).ToList();
                    break;
                case "fav":
                    EngineMaikaTI.LoggedUser.Notebooks = EngineMaikaTI.LoggedUser.Notebooks.OrderByDescending(a => a.IsFavourite).ToList();
                    break;
            }

            return Messages.SortedSuccessfully(sortingType);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Way to Sort (nameAS, nameDS, Fav): "));
            this.Parameters = inputParameters;
        }
    }
}
