using System;
using System.Threading;
using TODO.Contracts;

namespace TODO.Models
{
    public class Reminder : IReminder, ISaveable
    {
        private TimeSpan momentToRemind;

        public Reminder(TimeSpan momentToRemind)
        {
            this.MomentToRemind = momentToRemind;
        }

        public TimeSpan MomentToRemind
        {
            get
            {
                return this.momentToRemind;
            }
            private set
            {
                this.momentToRemind = value;
            }
        }

        public void Remind(object state)
        {
            
            Writer.RemindText("GG WP");
        }

        public string FormatUserInfoForDB()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            var dt = new DateTime(2000, 2,
                2,
                this.MomentToRemind.Hours,
                this.MomentToRemind.Minutes,
                this.MomentToRemind.Seconds).ToString("HH/mm/ss");
            return $"{dt}";
        }
    }
}
