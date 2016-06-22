using System;

namespace WpfBase
{
    public class SimpleCommand : DelegateCommandBase
    {
        public SimpleCommand(Action<object> act)
            : base(act)
        {

        }
        public SimpleCommand(Action act)
            : base(param => act())
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
