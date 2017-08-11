using System;
using System.Collections.Generic;
using TODO.Factories;
using TODO.Utils.Validator;

namespace TODO.Engine
{
    public abstract class Command : ICommand
    {
        private List<string> parameters;

        public Command()
        {           
            this.Factory = new OrganizerFactory();
        }

        protected List<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            set
            {
                Validator.ListCannotBeNullOrEmpty(value);
                
                this.parameters = value;
            }
        }
        protected OrganizerFactory Factory
        {
            get;
        }
        public abstract string Execute();

        public abstract void TakeInput();

        protected virtual string ReadOneLine(string instruction)
        {
            Console.Write(instruction);
            return Console.ReadLine();
        }
    }
}
