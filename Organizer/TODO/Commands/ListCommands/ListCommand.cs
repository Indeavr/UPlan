using TODO.Engine;

namespace TODO.Commands
{
    class ListCommand : Command, ICommand
    {
        public override string Execute()
        {
            return EngineMaikaTI.LoggedUser.ToString();
        }

        public override void TakeInput()
        {
        }
    }
}