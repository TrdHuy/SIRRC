using SIRRC.Base.UIEventHandler.Action;
using SIRRC.Base.UIEventHandler.Action.Executer;
using SIRRC.Base.UIEventHandler.Helpers;
using System;

namespace SIRRC.Base.InputCommand
{
    public class NavigationCommandExecuterModel : CommandExecuterModel
    {
        private INavigationCommandExecuter _commandExecuterCache;
        protected override ICommandExecuter CommandExecuterCache { get => _commandExecuterCache; set => _commandExecuterCache = value as INavigationCommandExecuter; }
        public NavigationCommandExecuterModel(Func<object, ICommandExecuter> getCmdExecuterFunc, CommandExecuteHelper cmdExeHelper) : base(getCmdExecuterFunc, cmdExeHelper)
        {
        }

        protected override void ExetcuteAction(object dataTransfer)
        {
            if (CommandExecuterCache == null)
            {
                return;
            }

            if (CommandExecuteHelper.Status == HelperStatus.RemainSomeExecutingActions
                && ((INavigationCommandExecuter)CommandExecuterCache).PreviewGoToNewSource())
            {
                //if the navigation action is going to navigating to new source, cancel all current processing action
                CommandExecuteHelper.CancelAllAction();

                base.ExetcuteAction(dataTransfer);
            }
            else
            {
                base.ExetcuteAction(dataTransfer);
            }

        }
    }
}
