using System;
using TODO.Commands;
using TODO.Commands.TaskCommands;
using TODO.Contracts;
using TODO.Factories;
using TODO.Utils.GlobalConstants;

namespace TODO.Engine
{
    public class EngineMaikaTI : IEngine
    {
        public void Start()
        {
            while (true)
            {
                try
                {
                    string commands = this.ReadCommands();

                    if (commands.Equals("exit"))
                    {
                        break;
                    }
                    if (string.IsNullOrEmpty(commands)) // checks if its null or if the first element is nullOrEmpty
                    {
                        continue;
                    }

                    this.ProcessCommands(commands);
                    if (LoggedUser != null)
                    {
                        Saver.CreateUserFile(LoggedUser);
                    }
                    //this.PrintReports(commandResult);

                }
                catch (Exception ex)
                {
                    Writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommands(string commands)
        {
            string commandType = String.Join(string.Empty, commands.Split());
            ICommand command = null;
            string commandResult = String.Empty;

            switch (commandType )
            {
                case "register":
                case "registeruser":
                    command = new RegisterCommand();
                    break;
                case "login":
                case "log":
                    command = new LoginCommand();
                    break;
                case "logout":
                    command = new LogOutCommand();
                    break;
                case "addnotebook":
                    command = new AddNotebookCommand();
                    break;
                case "addnote":                   
                    if (LoggedUser.Notebooks.Count == 0)
                    {
                        throw new ArgumentException(Messages.MustCreateANotebook());
                    }
                    command = new AddNoteCommand();
                    break;
                case "switchnotebook":
                    command = new SwitchNotebookCommand();
                    break;
                case "addtask":
                    command = new AddTaskCommand();
                    break;
                case "addlongtermtask":
                    command = new AddLongTermTaskCommand();
                    break;
                case "addsubtask":
                    command = new AddSubtaskCommand();
                    break;
                case "addremindertotask":
                    command = new AddReminderToTaskCommand();
                    break;
                case "addnotetofavourites":
                    command = new AddNoteToFavouritesCommand();
                    break;
                case "addnotebooktofavourites":
                    command = new AddNotebookToFavouritesCommand();
                    break;
                case "listall":
                    command = new ListCommand();
                    break;
                case "listtask":
                    command = new ListTask();
                    break;
                case "listnotebook":
                    command = new ListNotebookCommand();
                    break;
                case "listnote":
                    command = new ListNoteCommand();
                    break;
                case "listlongtermtask":
                    command = new ListLongTermTaskCommand();
                    break;
                case "listsubtask":
                    command = new ListSubTaskCommand();
                    break;
                case "switchlongtertask":
                    command = new SwitchLongTermTaskCommand();
                    break;
                case "deletetask":
                    command = new DeleteTaskCommand();
                    break;
                case "deletesubtask":
                    command = new DeleteSubTaskCommand();
                    break;
                case "clearhistory":
                    command = new ClearHistoryCommand();
                    break;
                case "sortallnotebooks":
                    command = new SortNotebooksCommand();
                    break;
                case "sortnotebook":
                    command = new SortNotebookCommand();
                    break;
                case "sorttasks":
                    command = new SortTasksCommand();
                    break;
                default:
                    throw new ArgumentException("Wrong Command");
            }

            command.TakeInput();
            commandResult = command.Execute();
            Writer.WriteLine(commandResult);
        }

        private string ReadCommands()
        {
            string command = Console.ReadLine().ToLower().Trim();

            bool isUserCreatable = LoggedUser == null && command != "login" && command != "register";

            if (isUserCreatable)
            {
                Writer.NoUserLogged();
                command = ReadCommands();
            }
            return command;
        }

        public static IUser LoggedUser { get; set; }

        public static INotebook CurrentNotebook { get; set; }

        public static ILongTermTask CurrentLongTermTask { get; set; }

        public static string LastDescription { get; set; }
    }
}
