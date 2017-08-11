using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;
using System.Globalization;

namespace TODO.Commands
{
    class AddReminderToTaskCommand : Command, ICommand
    {
        public AddReminderToTaskCommand()
            : base()
        {
        }

        public override string Execute()
        {

            ////Note note = new Note("Homework", "I have to do my homework by the end of the week");
            ////Notebook notebook1 = new Notebook("First Notebook");

            //momentsToRemind.AddRange(EngineMaikaTI.loggedUser.Tasks.Where(t => t.Reminder != null).Select(x => x.Reminder));
            //// momentsToRemind.AddRange(EngineMaikaTI.loggedUser.LongTermTasks.Where(t => t.Reminder != null).Select(x => x.Reminder));
            //// momentsToRemind.AddRange(EngineMaikaTI.loggedUser.LongTermTasks.Where(s => s.AllTasks.Count > 0).Select(y => y.AllTasks).Where(t => t.Reminder != null).Select(x => x.Reminder));

           

            string taskName = base.Parameters[0];
            string momentToRemind = base.Parameters[1];

            DateTime dt = DateTime.ParseExact(momentToRemind, Constants.Formats,CultureInfo.InvariantCulture, DateTimeStyles.None);
            IReminder reminder = this.Factory.CreateReminder(dt,DateTime.Now);


            if (!SearchForTask(taskName))
            {
                throw new ArgumentException(Messages.WrongTaskName());
            }
            EngineMaikaTI.LoggedUser.Tasks.First(x => x.Title == taskName).Reminder = reminder;


            TimerCallback callback = new TimerCallback(reminder.Remind);
            Timer timer = new Timer(callback,null, EngineMaikaTI.LoggedUser.Tasks.Single(x => x.Title == taskName).Reminder.MomentToRemind, TimeSpan.FromMilliseconds(-1));
            //
            //timer.Change();
            return Messages.AddedReminderToTask(taskName);
            //return $"Created reminder to task: {taskName} successfully !";
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Task name: "));
            inputParameters.Add(this.ReadOneLine("When to remind: "));
            this.Parameters = inputParameters;
        }

        private bool SearchForTask(string taskName)
        {
            foreach (var task in EngineMaikaTI.LoggedUser.Tasks)
            {
                if (task.Title == taskName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
