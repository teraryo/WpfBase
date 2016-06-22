using System;

namespace liquid_app_prince_front.Base
{

    public abstract class DelegateCommandBase : CommandBase
    {
        private Action<object> onExecute;
        public DelegateCommandBase(Action<object> act)
        {
            this.onExecute = act;
        }

        public override void Execute(object o)
        {
            onExecute(o);
        }
    }
}
