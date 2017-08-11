using System;
using TODO.Contracts;

namespace TODO.Models
{
    public class Note : Assignment, INote, ISaveable,IAssignement
    {      
        private bool isFavourite;

        public Note(string title, string content, bool isFavourite = false, DateTime dateOfCreation = default(DateTime))
            :base(title, content, dateOfCreation)
        {
           
            this.IsFavourite = isFavourite;
        }

        
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }
            set
            {
                this.isFavourite = value;
            }
        }

        public string FormatUserInfoForDB()
        {
            return $"{this.Title}***{this.IsFavourite}***{this.DateOfCreation.ToString("dd/MM/yyyy")}***{this.Content}";
        }

        public override string ToString()
        {
            return string.Concat(
                new string(' ', 12), "Note", new string(' ', 13),
                Environment.NewLine,
                new string('-', 29),
                Environment.NewLine,
                $"Name: {this.Title}",
                Environment.NewLine,
                $"{(this.IsFavourite == true ? "Favourite" : "Not favourite")}",
                Environment.NewLine,
                "Created: ", this.DateOfCreation.ToString("HH/mm/dd/MM/yyyy"),
                Environment.NewLine,
                new string('_', 9), "Description", new string('_', 9),
                Environment.NewLine,
                this.Content,
                Environment.NewLine,
                new string('-', 29),
                Environment.NewLine);



            //$"   ###{this.Title}### created: {this.DateOfCreation:dd/MM/yyyy}" + Environment.NewLine +
            // $"      DESCRIPTION:{this.Content}.";
        }
    }
}
