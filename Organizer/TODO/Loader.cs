using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TODO.Contracts;
using TODO.Models;
using TODO.Utils.GlobalConstants;

namespace TODO
{
    public static class Loader
    {
        public static List<string> LoadUsernamesAndPasswords()
        {
            List<string> allUsers = new List<string>();
            using (StreamReader reader = new StreamReader(Constants.PathToDatabase + "/DatabaseOfUsernames.txt"))
            {
                allUsers = reader.ReadToEnd()
                    .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            return allUsers;
        }

        public static IUser LoadUser(string username, string password)
        {
            using (StreamReader reader = new StreamReader($"{Constants.PathToDatabase}/{username}_UserDatabase.txt"))
            {
                reader.ReadLine();
                List<INotebook> currNotebooks = new List<INotebook>();
                while (true)
                {
                    string attrLine = reader.ReadLine();
                    if (attrLine == "---***---")
                        break;
                    currNotebooks.Add(LoadNotebook(attrLine));
                }

                List<ITask> currTasks = new List<ITask>();
                while (true)
                {
                    string attrLine = reader.ReadLine();
                    if (attrLine == "___***___")
                        break;
                    currTasks.Add(LoadTask(attrLine));
                }

                List<ILongTermTask> currLongTermTasks = new List<ILongTermTask>();
                while (true)
                {
                    string attrLine = reader.ReadLine();
                    if (attrLine == "---***---")
                        break;
                    currLongTermTasks.Add(LoadLongTermTask(attrLine));
                }
                return new User(username, password, currNotebooks, currTasks, currLongTermTasks);
            }
        }

        public static INotebook LoadNotebook(string notebookParametersString)
        {
            string[] notebookParameters = notebookParametersString
                .Split(new string[] { ":::" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string title = notebookParameters[0];
            bool refinednotebookParam = notebookParameters[1] == "True";
            List<INote> currNotes = new List<INote>();

            if (notebookParameters[2] != "None")
            {
                currNotes = notebookParameters[2].Split(new string[] { ",,," }, StringSplitOptions.RemoveEmptyEntries).Select(x => LoadNote(x)).ToList();
            }

            return new Notebook(title, refinednotebookParam, currNotes);
        }

        private static INote LoadNote(string noteParameteresString)
        {
            string[] noteParameters = noteParameteresString.Split(new string[] { "***" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string title = noteParameters[0];
            bool refinednoteParam = noteParameters[1] == "True";
            var dt = DateTime.ParseExact(noteParameters[2], Constants.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var content = noteParameters[3];

            return new Note(title, content, refinednoteParam, dt);
        }

        private static ISubTask LoadSubTask(string subTaskParametersString)
        {

            string[] subTaskParameters = subTaskParametersString.Split(new string[] { "***" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string title = subTaskParameters[0];

            Priority priority = (Priority)Enum.Parse(typeof(Priority), subTaskParameters[1]);

            Reminder reminder = new Reminder(DateTime.ParseExact(subTaskParameters[2], Constants.TimeSpanFormats, CultureInfo.InvariantCulture, DateTimeStyles.None).TimeOfDay);
            DateTime dtStart = DateTime.ParseExact(subTaskParameters[3], Constants.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime dtDueDate = DateTime.ParseExact(subTaskParameters[4], Constants.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None);

            double importancePercent = double.Parse(subTaskParameters[5]);
            string description = subTaskParameters[6];

            return new SubTask(title, priority, description, dtDueDate, importancePercent, dtStart,reminder);
        }

        private static ITask LoadTask(string taskParameteresString)
        {
            string[] taskParameters = taskParameteresString.Split(new string[] { ":::" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string title = taskParameters[0];
            Priority priority = (Priority)Enum.Parse(typeof(Priority), taskParameters[1]);
            Reminder reminder = new Reminder(DateTime.ParseExact(taskParameters[2], Constants.TimeSpanFormats, CultureInfo.InvariantCulture,DateTimeStyles.None).TimeOfDay);

            DateTime dt = DateTime.ParseExact(taskParameters[3], Constants.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            string description = taskParameters[4];
            return new Task(title, priority, description,reminder,dt);
        }

        private static ILongTermTask LoadLongTermTask(string longTermTaskParametersString)
        {
            string[] longTermTaskParameters = longTermTaskParametersString.Split(new string[] { ":::" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string title = longTermTaskParameters[0];

            Priority priority = (Priority)Enum.Parse(typeof(Priority), longTermTaskParameters[1]);

            List<ISubTask> currSubtasks;
            if (longTermTaskParameters[4] == "None")
            {
                currSubtasks = new List<ISubTask>();
            }
            else
            {
                currSubtasks = longTermTaskParameters[4].Split(new string[] { ",,," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => LoadSubTask(x)).ToList();
            }
            DateTime dtStart = DateTime.ParseExact(longTermTaskParameters[3], Constants.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            Reminder reminder = new Reminder(DateTime.ParseExact(longTermTaskParameters[2], Constants.TimeSpanFormats, CultureInfo.InvariantCulture, DateTimeStyles.None).TimeOfDay);


            DateTime dtEnd = DateTime.ParseExact(longTermTaskParameters[5].Trim(), Constants.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            string description = longTermTaskParameters[6];

            return new LongTermTask(title, priority, dtEnd, description,dtStart,reminder,currSubtasks);
        }
    }
}