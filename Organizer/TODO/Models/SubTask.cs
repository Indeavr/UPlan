using System;
using TODO.Contracts;

namespace TODO.Models
{
    public class SubTask : Task, ITask, ISubTask, ISaveable
    {
        private DateTime dueDate;
        private double importancePercent;

        public SubTask(string title, Priority priority, string description, DateTime dueDate, double importancePercent,DateTime dateOfCreation)
            : base(title, priority, description, dateOfCreation)
        {
            this.DueDate = dueDate;
            this.ImportancePercent = importancePercent;
            
        }

        public SubTask(string title, Priority priority, string description, DateTime dueDate, double importancePercent, DateTime dateOfCreation,Reminder reminder)
            :this(title,priority,description,dueDate,importancePercent,dateOfCreation)
        {
            this.Reminder = reminder;
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }

            private set
            {
                this.dueDate = value;
            }

        }

        public double ImportancePercent
        {
            get
            {
                return this.importancePercent;
            }
            set
            {
                this.importancePercent = value;
            }
        }
        public override string AdditionalPrintingInformation()
        {
            return string.Concat("Due date: ", this.DueDate.ToString("dd/MM/yyyy"),
                Environment.NewLine,
                "Percent of whole task: ", this.ImportancePercent,
                Environment.NewLine);
        }
        public override string FormatUserInfoForDB()
        {
            return $"{this.Title}***{this.Priority}***{(this.Reminder == null ? "None" : this.Reminder.ToString())}" +
                   $"***{this.DateOfCreation.ToString("HH/mm/dd/MM/yyyy")}***{this.DueDate.ToString("HH/mm/dd/MM/yyyy")}***{this.ImportancePercent}***{this.Content}";
        }
        public override string ToString()
        {
            return string.Concat(Environment.NewLine, "--------> ", "Subtask", Environment.NewLine, base.ToString());
        }
    }
}