using System;
using TODO.Utils.Validator;

namespace TODO.Models
{
    public abstract class Assignment 
    {
        private string title;
        private string content;
        private DateTime dateOfCreation;
        public Assignment(string title, string content, DateTime dateOfCreation)
        {
            this.Title = title;
            this.Content = content;
            this.DateOfCreation = dateOfCreation;
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                Validator.CannotBeNullOrEmpty(value);

                this.title = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                Validator.CannotBeNullOrEmpty(value);

                this.content = value;
            }
        }

        public DateTime DateOfCreation
        {
            get
            {
                return this.dateOfCreation;
            }
            protected set
            {
                if (value == default(DateTime))
                {
                    this.dateOfCreation = DateTime.Now;
                }
                else
                {
                    this.dateOfCreation = value;
                }
            }
        }     
    }
}
