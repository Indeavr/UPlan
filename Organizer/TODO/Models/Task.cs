using System;
using TODO.Contracts;
using TODO.Models;

namespace TODO
{
    public class Task : Assignment ,ITask, ISaveable,IAssignement
    {      
        private Priority priority;
        private IReminder reminder;
     
        public Task(string title, Priority priority, string content, DateTime dateOfCreation = default(DateTime))
            :base(title,content,dateOfCreation)
        {      
            this.Priority = priority;          
            this.Reminder = reminder;
        }
        public Task(string title, Priority priority, string content,Reminder reminder, DateTime dateOfCreation = default(DateTime))
            : this(title, priority, content, dateOfCreation)
        {
            this.Reminder = reminder;
        }


        public Priority Priority
        {
            get
            {
                return this.priority;
            }
            private set
            {
                this.priority = value;
            }
        }

        public IReminder Reminder
        {
            get
            {
                return this.reminder;
            }
            set
            {
                this.reminder = value;
            }
        }

        public virtual string AdditionalInformation()
        {
            return "";
        }
        public virtual string AdditionalPrintingInformation()
        {
            return string.Empty;
        }

        public virtual string FormatUserInfoForDB()
        {
            return $"{this.Title}:::{this.Priority}:::{(this.Reminder == null ? "None" : this.Reminder.ToString())}" +
                   $":::{this.DateOfCreation:dd/MM/yyyy}:::{AdditionalInformation()}:::{this.Content}";
        }

        public override string ToString()
        {
            return string.Concat($"Name: {this.Title}",
                Environment.NewLine,
                $"Created: {this.DateOfCreation.ToString("HH:mm/dd/MM/yyyy")}",
                Environment.NewLine,
                "You will be reminded at: ", $"{(this.Reminder == null ? "No reminder set" : $"{this.Reminder.MomentToRemind.ToString("HH:mm:ss")}")}",
                Environment.NewLine,
                AdditionalPrintingInformation(),
                Environment.NewLine,
                new string('_', 10), "Description", new string('_', 10),
                Environment.NewLine,
                this.Content,
                Environment.NewLine);
        }
    }
}
