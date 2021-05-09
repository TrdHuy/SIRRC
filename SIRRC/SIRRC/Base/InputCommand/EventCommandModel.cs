using System;

namespace SIRRC.Base.InputCommand
{
    public class EventCommandModel
    {
        private Handle handler;

        public EventCommandModel(Handle obj)
        {
            handler = obj;
        }

        public void Execute(object sender, EventArgs eventArgs, params object[] parameters)
        {
            handler?.Invoke(sender, eventArgs, parameters);
        }
    }

    public delegate void Handle(object sender, EventArgs e, object paramater);

}
