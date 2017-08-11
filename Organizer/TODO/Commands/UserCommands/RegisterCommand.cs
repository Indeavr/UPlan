using System;
using System.Collections.Generic;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class RegisterCommand : Command, ICommand
    {
        private List<string> usernamesInDatabase = Loader.LoadUsernamesAndPasswords();

        public RegisterCommand()
            : base()
        {

        }

        public override string Execute()
        {
            string username = base.Parameters[0];
            string password = base.Parameters[1];

            if (!CheckIfUsernameIsTaken(username))
            {
                throw new ArgumentException("Username is Taken !");
            }

            EngineMaikaTI.LoggedUser = base.Factory.CreateUser(username, password);
            Saver.SaveUsernamesAndPasswords(username, password);

           return Messages.UserCreated(username); 
        }

        private bool CheckIfUsernameIsTaken(string username)
        {
            foreach (var name in this.usernamesInDatabase)
            {
                string currentUsername = name.Split()[0];
                if (username == currentUsername)
                {
                    return false;
                }
            }
            return true;
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Username: "));
            inputParameters.Add(this.ReadOneLine("Password: "));
            this.Parameters = inputParameters;
        }
    }
}
